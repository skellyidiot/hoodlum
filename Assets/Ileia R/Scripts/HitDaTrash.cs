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
    bool f = false;
    // Update is called once per frame
    public float timer = 0.0f;

    void Update()
    {
        if(f == true)
        {
            timer += Time.deltaTime;
            float seconds = timer % 60;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PhysicsObjects")
        {
            Debug.Log("Hi");
            float vel = Mathf.Abs(rb2d.velocity.x) + Mathf.Abs(rb2d.velocity.y);
            float rot = Vector2.Angle(Vector2.up, rb2d.velocity.normalized);
            print(rot);
            collision.gameObject.GetComponent<PhysicsHitObject>().Hit(vel,transform.position,rot);
        }else if(collision.gameObject.tag == "NPC")
        {
            collision.gameObject.GetComponent<PatrolScript2D>().enabled = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        f = true;
        if(timer > 3)
        {
            collision.gameObject.GetComponent<PatrolScript2D>().enabled = true;
            timer = 0f;
            f = false;
        }
    }
    
}
