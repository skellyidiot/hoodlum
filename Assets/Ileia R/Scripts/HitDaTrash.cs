using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDaTrash : MonoBehaviour
{
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PhysicsObjects")
        {
            Debug.Log("Hi");
            float vel = Mathf.Abs(rb2d.velocity.x) + Mathf.Abs(rb2d.velocity.y);
            collision.gameObject.GetComponent<PhysicsHitObject>().Hit(vel,transform);
        }
    }
}
