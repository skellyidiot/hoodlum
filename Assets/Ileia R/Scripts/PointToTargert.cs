using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointToTargert : MonoBehaviour
{
    public float speed = 2f;
    public SpriteRenderer sr;
    //task 1 objects
    public GameObject safe;
    public GameObject GoIn;
    //task 2 objects
    public GameObject Leader;
    public GameObject DropOff;
    //task 3 objects
    public GameObject Location;

    //TASK 4 OBJECTS
    public GameObject stairsUp;
    public GameObject MobBoss;
    public GameObject stairsDown;


    // Update is called once per frame

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    void Update()
    {
        if(TaskmanTXTbox.doingTask1 == false && TaskmanTXTbox.doingTask2 == false && TaskmanTXTbox.doingTask1 == false)
        {
            sr.enabled = false;
        }
        if (TaskmanTXTbox.doingTask1 == true && TaskmanTXTbox.doneTask1 == false && AllTasks.isInBuilding == false)
        {
            sr.enabled = true;
            Vector3 vectorToTarget = transform.position - GoIn.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        if (AllTasks.isInBuilding == true && AllTasks.hasInfo == false && TaskmanTXTbox.doneTask1 == false)
        {
            sr.enabled = true;
            Vector3 vectorToTarget = transform.position - safe.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        if(AllTasks.hasInfo == true)
        {
            sr.enabled = false;
        }

        if (TaskmanTXTbox.doingTask2 == true && TaskmanTXTbox.doneTask2 == false && AllTasks.LeaderInCar == false)
        {
            sr.enabled = true;
            Vector3 vectorToTarget = transform.position - Leader.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        
        if (TaskmanTXTbox.doingTask2 == true && TaskmanTXTbox.doneTask2 == false && AllTasks.LeaderInCar == true)
        {
            sr.enabled = true;
            Vector3 vectorToTarget = transform.position - DropOff.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        if (TaskmanTXTbox.doingTask3 == true && TaskmanTXTbox.doneTask3 == false)
        {
            sr.enabled = true;
            Vector3 vectorToTarget = transform.position - Location.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

        //task 4
        if(TaskmanTXTbox.doingTask4 == true)
        {
            sr.enabled = true;
            Vector3 vectorToTarget = transform.position - stairsUp.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
}
