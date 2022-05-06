using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PatrolScript2D : MonoBehaviour

{// Start is called before the first frame update



    public List<Transform> patrolPts = new List<Transform>();

    Transform[] patrolPoints = new Transform[] { };

    public int patrolPath;

    public float pathTime;
    public float speed = 2.0f;
    public float currentTime;
    public float angle;
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
    public List<GameObject> peopleList = new List<GameObject>();
    void Start()

    {
        foreach (GameObject NPC in GameObject.FindGameObjectsWithTag("people"))
        {

            patrolPts.Add(NPC.transform);
        }

        patrolPath = Random.Range(0, patrolPts.Count);

        Debug.Log(patrolPath);

        patrolPoints = patrolPts.ToArray();

        nPoints = patrolPoints.Length;

        distance = Vector3.Distance(patrolPts[0].transform.position, patrolPts[1].transform.position);

        ratio = (distance / pathTime) * Time.deltaTime;

        turnTowardsTarget();



    }



    // Update is called once per frame

    void Update()

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

            patrolPath++;

            if (patrolPath > nPoints - 1) patrolPath = 0;







            turnTowardsTarget();



        }

        transform.position = Vector3.Lerp(patrolPoints[patrolPath].position, patrolPoints[(patrolPath + 1) % nPoints].position, currentTime / (speed));



    }


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "car")

    //        Destroy(this.gameObject);
    //}
    public void turnTowardsTarget()

    {



        Vector2 startLocation = patrolPoints[patrolPath % nPoints].position;

        Vector2 endLocation = patrolPoints[(patrolPath + 1) % nPoints].position;

        Vector2 pathDirection = endLocation - startLocation;

        float angle = Mathf.Atan2(pathDirection.y, pathDirection.x) * Mathf.Rad2Deg;

        //Debug.Log(pathDirection + " " + angle);

        Debug.Log("------");

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

    }

    public void turnTowardsTarget(Vector2 start)

    {



        Vector2 startLocation = start;

        Vector2 endLocation = patrolPoints[(patrolPath + 1) % nPoints].position;

        Vector2 pathDirection = endLocation - startLocation;

        float angle = Mathf.Atan2(pathDirection.y, pathDirection.x) * Mathf.Rad2Deg;

        Debug.Log(pathDirection + " " + angle);

        Debug.Log("------");

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

    }

}