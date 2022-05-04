using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTwoPointO : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 10f);

        if (hit)
        {
            Debug.Log("Hit");
        }
    }
}
