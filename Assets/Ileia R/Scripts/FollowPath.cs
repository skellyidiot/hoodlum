using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowPath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;
    public bool goesback;
    public bool loops;

    bool backing;
    // Index of current waypoint from which Enemy walks
    // to the next one
    public int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        // Move Enemy
        if (AllTasks.isInBuilding)
        {
            Move();
        }
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops

        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypointa
            
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (backing == false)
                {
                    waypointIndex += 1;
                }
                else
                {
                    waypointIndex -= 1;
                }
            }
        }

        else if (loops)
        {
            waypointIndex = 0;
        }
        else if (goesback)
        {
            backing = true;
            waypointIndex -= 1;
        }
        if (waypointIndex < 0)
        {
            waypointIndex = 0;
            backing = false;
        }
    }
}
