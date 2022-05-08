using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RayCastTwoPointO : MonoBehaviour
{
    public LayerMask layer;

    public Transform firePoint;
    public GameObject bulletprefab;
    public GameObject muzzle;

    public float force = 20f;

    public float ShootTimer;
    public float viewdist = 8f;

    bool agro;
    float agrotimer = 0;
    public GameObject player = null;
    bool seeking;

    int HP = 100;
    Rigidbody2D rb;

    public EnemySeek es;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        es = GetComponent<EnemySeek>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, viewdist);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, rotateVector(transform.up,45), viewdist);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, rotateVector(transform.up, -45), viewdist);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, rotateVector(transform.up, -22.5f), viewdist);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, rotateVector(transform.up, 22.5f), viewdist);
        RaycastHit2D hit5 = Physics2D.Raycast(transform.position, rotateVector(transform.up, 11.25f), viewdist);
        RaycastHit2D hit6 = Physics2D.Raycast(transform.position, rotateVector(transform.up, -11.25f), viewdist);
        RaycastHit2D hit7 = Physics2D.Raycast(transform.position, rotateVector(transform.up, -67.5f), viewdist);
        RaycastHit2D hit8 = Physics2D.Raycast(transform.position, rotateVector(transform.up, 67.5f), viewdist);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up),-45) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up),45) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up), -22.5f) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up), 22.5f) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up), -11.25f) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up), 11.25f) * viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up), 67.5f) *viewdist, Color.green);
        Debug.DrawRay(transform.position, rotateVector(transform.TransformDirection(Vector2.up), -67.5f) * viewdist, Color.green);
        List<RaycastHit2D> hitting = new List<RaycastHit2D>();
        if (hit)
        {
            hitting.Add(hit);
        }
        if (hit1)
        {
            hitting.Add(hit1);
        }
        if (hit2)
        {
            hitting.Add(hit2);
        }
        if (hit3)
        {
            hitting.Add(hit3);
        }
        if (hit4)
        {
            hitting.Add(hit4);
        }
        if (hit6)
        {
            hitting.Add(hit6);
        }
        if (hit5)
        {
            hitting.Add(hit5);
        }
        if (hit7)
        {
            hitting.Add(hit7);
        }
        if (hit8)
        {
            hitting.Add(hit8);
        }
        if (player != null)
        {
            Vector2 posdif = (transform.position - player.transform.position);
            posdif  += player.GetComponent<PlayerMovement>().movementdif * 15;
            float rot_z = Mathf.Atan2(posdif.y, posdif.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        }
        if (hitting.Count > 0)
        {
            bool phit = false;
           foreach (RaycastHit2D h in hitting)
            {
                if (h.collider.gameObject.tag == "Player")
                {
                    agro = true;
                    phit = true;
                    player = h.collider.gameObject;
                    
                    agrotimer = 0;

                }
            }
           if (seeking)
            {

                agrotimer += Time.deltaTime;
                if (agrotimer > 2.5)
                {
                    seeking = false;
                    agrotimer = 0;
                    es.enabled = false;
                }
            }
           if (phit == false)
            {
                if (agro)
                {
                    
                    agrotimer += Time.deltaTime;
                    if (agrotimer >= 1)
                    {
                        es.target = player.transform;
                        seeking = true;
                        
                        player = null;
                        agro = false;
                        agrotimer = 0;
                        es.enabled = true;
                        es.Ready();

                    }
                }
            }
            if (agro)
            {
                viewdist = 14f;
                gameObject.GetComponent<FollowPath>().enabled = false;
                
                ShootTimer += Time.deltaTime;
                if (ShootTimer >= 0.5)
                {
                    ShootTimer = 0;
                    Shoot();
                }
                Strafe();

            }
            else if (!seeking)
            {
                viewdist = 8f;
                gameObject.GetComponent<FollowPath>().enabled = true;
                
            }
        }

    }
    Vector2 rotateVector(Vector2 vec, float degrees)
    {

        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = vec.x;
        float ty = vec.y;
        vec.x = (cos * tx) - (sin * ty);
        vec.y = (sin * tx) + (cos * ty);
        return vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            player = collision.gameObject.GetComponent<Bullet>().Owner;
            Destroy(collision.gameObject);
            agro = true;
            HP -= 20;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            agro = true;
        }
    }
    void Strafe()
    {
        rb.AddForce(-player.GetComponent<PlayerMovement>().movementdif * 9000   * Time.deltaTime);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Bullet>().Owner = this.gameObject;

        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        Debug.Log("Shooting");
    }
}
