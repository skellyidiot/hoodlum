using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJECTMoveTutText : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "COLLIDER")
        {
            Destroy(this.gameObject);
        }
    }
}
