using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySeek : MonoBehaviour
{ 
    public Transform target;
    float speed = 8f;
    float nextwaydist = 1f;

    Path path;
    public int currwaypoint;

    bool atend = false;

    public float timer = 0;

    public bool active = false;

    public bool returntopoint;
    public bool returning;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        

    }

    public void SetPath()
    {
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    // Update is called once per frame
    public void Ready()
    {
        //いたい
        //僕を殺して
        print(target.position);
        SetPath();

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
                if (returning)
                {

                    GetComponent<RayCastTwoPointO>().doneSeeking();
                    returning = false;
                }
                else
                {
                    timer += 1;
                    if (timer >= 60)
                    {
                        timer = 0;
                        GetComponent<Animator>().SetBool("Gun", false);
                        seeker.StartPath(transform.position, GetComponent<FollowPath>().waypoints[GetComponent<FollowPath>().waypointIndex].position, OnPathComplete);
                        returning = true;
                    }
                }
                
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

            float rot_z = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
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
