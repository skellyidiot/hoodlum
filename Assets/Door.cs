using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool Open = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            GetComponent<HingeJoint2D>().useMotor = true;
            if (Open != true)
            {
                GetComponent<AudioSource>().Play();
                Open = true;
            }
        }
    }
}
