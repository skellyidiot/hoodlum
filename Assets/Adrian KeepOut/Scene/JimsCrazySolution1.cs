using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimsCrazySolution1 : MonoBehaviour
{

    private bool dirRight = true;
    public float speed = 2.0f;
    public List<Transform> patrolPts = new List<Transform>();

    Transform[] patrolPoints = new Transform[] { };

    private int patrolPath;

    public float pathTime;
    public float angle;
    public float currentTime;
    public float offset;
    int nPoints;
    public float ratio;
    private float distance;
    public Quaternion currentAngle;
    public Vector2 NormalVector;
    public Vector2 NextPosion;
    public Vector3 direction;
    public Vector2 endLocation;
    public Vector2 startLocation;
    public Vector2 pathDirection;
    public bool spawnedAtlastPos;

    public float speed2;
    public float stoppingDistance;

    public Transform target;
    
    void Start()

    {
        target = target.GetComponent<Transform>();
        var ycount = Random.Range(0, patrolPoints.Length);
        patrolPath = ycount;

        patrolPoints = patrolPts.ToArray();

        nPoints = patrolPoints.Length;
        

        distance = Vector3.Distance(patrolPts[0].transform.position, patrolPts[1].transform.position);

        ratio = (distance / pathTime) * Time.deltaTime;
        
        
        

        var heading = new Vector2(patrolPts[patrolPath+1].transform.position.x, patrolPts[patrolPath+1].transform.position.y) - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        turnTowardsTarget();
        

    }



    // Update is called once per frame

    void Update()

    {
        if(Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed2 * Time.deltaTime);
        }
        else
        {
            distance = Vector3.Distance(patrolPoints[patrolPath].position, patrolPoints[(patrolPath + 1) % nPoints].position);

            float speed = distance * ratio * 10f;
            pathTime = speed;
            currentTime += Time.deltaTime;
            NormalVector = new Vector2(-patrolPoints[patrolPath].position.y, patrolPoints[patrolPath].position.x);
            NextPosion = new Vector2(patrolPoints[(patrolPath + 1) % nPoints].position.x, patrolPoints[(patrolPath + 1) % nPoints].position.y);
            angle = Vector2.Dot(NormalVector, NextPosion);
            currentTime += Time.deltaTime;


            if (currentTime > speed)

            {

                currentTime = 0; //reset the timer
                                 //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, 0.2f);
                patrolPath++;


                if (patrolPath > nPoints - 1) patrolPath = 0;

                turnTowardsTarget();

            }

            transform.position = Vector3.Lerp(patrolPoints[patrolPath].position, patrolPoints[(patrolPath + 1) % nPoints].position, (currentTime / (speed)));
        }
        
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, 0.2f);

        //StartCoroutine(Rotate());

    }
    public void turnTowardsTarget(Transform target)

    {
        startLocation = patrolPoints[patrolPath % nPoints].position; // line 49
        endLocation = patrolPoints[(patrolPath + 1) % nPoints].position; // line 50
        pathDirection = endLocation - startLocation; // line 51
        float angle = Mathf.Atan2(pathDirection.y, pathDirection.x) * Mathf.Rad2Deg; // line 52

        Debug.Log(pathDirection + " " + angle); // line 53

        Debug.Log("------"); // line 54

        transform.rotation = Quaternion.Euler(0, 0, angle - 90); // line 55
        
        
       

    }


}

