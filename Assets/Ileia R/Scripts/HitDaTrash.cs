using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDaTrash : MonoBehaviour
{
    public AudioSource Car;
    public GameObject gos;
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

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PhysicsObjects")
        {
            Debug.Log("Hi");
            float vel = Mathf.Abs(rb2d.velocity.x) + Mathf.Abs(rb2d.velocity.y);
            float rot = Vector2.Angle(Vector2.up, rb2d.velocity.normalized);
            print(rot);
            collision.gameObject.GetComponent<PhysicsHitObject>().Hit(vel, transform.position, rot);
        }
        else if (collision.gameObject.tag == "NPC")
        {
            
            collision.gameObject.tag = "Hit";
            if(collision.gameObject.tag == "Hit"){
                Destroy(collision.gameObject);
                adfa.NPCCOUNT--;
            }

           
            //Debug.Log(adfa.NPCCOUNT);
            //collision.gameObject.GetComponent<PatrolScript2D>().enabled = false;

            //PatrolScript2D col2D = collision.gameObject.GetComponent<PatrolScript2D>();
            //Transform loc = collision.gameObject.GetComponent<Transform>();
            ////StartCoroutine(YES(col2D, loc));
            //collision.gameObject.tag = "NPC";
        }


    }
    

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    StartCoroutine(YES());
    //}

    IEnumerator YES(PatrolScript2D collision, Transform location)
    {
        yield return new WaitForSeconds(3);
        //gos = GameObject.FindGameObjectWithTag("Hit"); //PLAY SOUND
        collision.enabled = true;
        collision.turnTowardsTarget(new Vector2(location.transform.position.x, location.transform.position.y));
        Debug.Log("IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Car.mute = false;
        Car.Play();
    }
}
