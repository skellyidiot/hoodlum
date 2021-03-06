using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : PhysicsHitObject
{
    Animator anim;
    float time = 0;
    public GameObject Trash;
    public bool gothit = false;
    float Timer = 0;
    SpriteRenderer sr;
    public Vector3 startpos;
    Rigidbody2D rb;
    public Sprite StartSprite;
    // Start is called before the first frame update
    private void Start()
    {
        startpos = transform.position;
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {

    }
    public void OnBecameInvisible()
    {
        Respawn();
    }
    public override void Hit(float force,Vector3 pos ,float dir)
    {
        if (gothit != true)
        {
            base.Hit(force,pos , dir);
            GetComponent<AudioSource>().Play();
            anim.SetBool("hit", true);
            gothit = true;
            StartCoroutine(Wait());
            SpawnTrash();
            
        }
    }
    public void Respawn()
    {
        anim.SetBool("hit", false);
        anim.Play("");
        gothit = false;
        sr.color = new Color(1, 1, 1, 1);
        
        transform.position = startpos;
        transform.rotation = Quaternion.Euler(0,0,0);
        rb.velocity = new Vector2(0,0);
        rb.angularVelocity = 0;
        anim.Play("notknock");

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }
    void SpawnTrash()
    {
        int TrashAmnt = Random.Range(10, 30);
        for (int i = 0; i < TrashAmnt; i++)
        {
            GameObject e = Instantiate(Trash,transform.position, transform.rotation);
            e.GetComponent<trash>().Begin();
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PhysicsObjects")
        {
            float vel = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);
            float rot = Vector2.Angle(Vector2.up, rb.velocity.normalized);
            collision.gameObject.GetComponent<PhysicsHitObject>().Hit(vel, transform.GetChild(0).position, rot);
        }
    }
}
