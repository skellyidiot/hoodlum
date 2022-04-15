using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTasks : MonoBehaviour
{
    public GameObject arrow;
    //task 1
    public GameObject infosteal;
    public static bool hasInfo;

    //task 2 
    public GameObject leader;
    public static bool LeaderInCar;
    public GameObject dropOff;
    //taskman script
    public TaskmanTXTbox taskmanScript;

    //car script 
    public Car carScript;

    //task 3
    public GameObject pointB;
    public static float timeLeft = 60;
    public GameObject spawnerIfFail;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("arrow");
        arrow.SetActive(false);

        // task 1
        infosteal = GameObject.FindGameObjectWithTag("info");

        //task 2 
        leader = GameObject.FindGameObjectWithTag("Leader");
        leader.SetActive(false);
        dropOff.SetActive(false);

        //task 3
        pointB = GameObject.FindGameObjectWithTag("Point B");
        pointB.SetActive(false);
        spawnerIfFail = GameObject.FindGameObjectWithTag("failSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (TaskmanTXTbox.doingTask1 == true || TaskmanTXTbox.doingTask3 == true || TaskmanTXTbox.doingTask2 == true)
        {
            arrow.SetActive(true);
        }
        if (TaskmanTXTbox.doingTask1 == false && TaskmanTXTbox.doingTask3 == false && TaskmanTXTbox.doingTask2 == false)
        {
            arrow.SetActive(false);
        }
        //task 3
        if (TaskmanTXTbox.doingTask3 == true)
        {
            pointB.SetActive(true);
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            
        }
        if(timeLeft <= 0)
        {
            Debug.Log("no time left");
            //pointB.SetActive(false);
            gameObject.transform.position = spawnerIfFail.transform.position;
            timeLeft = 60;
            //TaskmanTXTbox.doingTask3 = false;
            TaskmanTXTbox.doneTask3 = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //task 1
        if(collision.gameObject.tag == "info" && hasInfo == false)
        {
            infosteal.SetActive(false);
            hasInfo = true;

            infosteal.transform.position = gameObject.transform.position;
        }
        if(collision.gameObject.tag == "TaskMan" && hasInfo == true)
        {
            hasInfo = false;
            TaskmanTXTbox.doneTask1 = true;
        }
        //Task 2
        if(TaskmanTXTbox.doingTask2 == true)
        {
            leader.SetActive(true);
        }
        if (Car.isDriving == true && collision.gameObject.tag == "Leader")
        {
            leader.SetActive(false);
            leader.transform.position = Car.car.transform.position;

            LeaderInCar = true;
            dropOff.SetActive(true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   //task 2
        if(collision.gameObject.tag == "DropOff" && LeaderInCar == true)
        {
            Destroy(leader);
            Destroy(dropOff);
            TaskmanTXTbox.doneTask2 = true;
        }
        //task 3
        if (collision.gameObject.tag == "Point B" && timeLeft > 0)
        {
            Debug.Log("------------------------------------Done 3------------------------------------");
            pointB.SetActive(false);
            TaskmanTXTbox.doneTask3 = true;
            timeLeft = 60;
        }

    }
}
