using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySeek : MonoBehaviour
{
    public Transform target;
    float speed = 10f;
    float nextwaydist = 1f;

    Path path;
    public int currwaypoint;

    bool atend = false;

    public float timer = 30;

    public bool active = false;

    public bool returntopoint;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    public void Ready()
    {
        //いたい
        //僕を殺して
        print(target.position);
        seeker.StartPath(transform.position, target.position, OnPathComplete);

    }
    void FixedUpdate()
    {
        if (active)
        {

            Vector3 oldpos = transform.position;
            if (path == null)
            {
                return;
            }
            if (currwaypoint >= path.vectorPath.Count)
            {
                atend = true;
                return;
            }
            else
            {
                atend = false;
            }

            Vector2 dir = ((Vector2)path.vectorPath[currwaypoint] - rb.position).normalized;
            Vector2 force = dir * speed * Time.deltaTime;


            float dist = Vector2.Distance(rb.position, path.vectorPath[currwaypoint]);


            rb.position += force;

            if (dist < nextwaydist)
            {
                currwaypoint++;
            }

            Vector2 posdif = oldpos - transform.position;
            posdif = posdif.normalized;
            if (posdif != new Vector2())
            {
                float rot_z = Mathf.Atan2(posdif.y, posdif.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
            }
        }
    }
    void OnPathComplete(Path P)
    {
        if (!P.error)
        {
            
            path = P;
            currwaypoint = 0;
        }
        else
        {
            print(P.error);
        }
    }
}
