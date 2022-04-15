using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasking : MonoBehaviour
{
    public GameObject art;
    public Transform artTransform;

    public GameObject collidedObject;
    // Start is called before the first frame update
    void Start()
    {
        art = GameObject.FindGameObjectWithTag("art");    
    }

    // Update is called once per frame
    void Update()
    {
        collidedObject.transform.position = transform.position;
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "art")
        {
            collidedObject = collision.gameObject;
        }
    }
}
