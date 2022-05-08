using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySeek : MonoBehaviour
{
    public Transform target;
    float speed = 20f;
    float nextwaydist = 3f;

    Path path;
    public int currwaypoint;

    bool atend = false;

    public float timer = 30;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    // Update is called once per frame
    public void Ready()
    {

        
    }
    void FixedUpdate()
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
    void OnPathComplete(Path P)
    {
        if (!P.error)
        {
            path = P;
            currwaypoint = 0;
        }
    }
}
