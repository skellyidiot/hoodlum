using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTasks : MonoBehaviour
{

    public static AllTasks TheTaskSctipt;

    public GameObject rain;
    public GameObject arrow;
    //task 1
    public static bool isInBuilding;
    public GameObject infosteal;
    public static bool hasInfo;
    public GameObject DropOfftext;
    public GameObject basket;
    public GameObject moneyText;

    public GameObject Room1Objects;
    public GameObject Room2Objects;

    public static GameObject room1Objects;
    public static GameObject room2Objects;

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

    public int Room = 0;

    //task 4
    public GameObject stairsUP;
    public GameObject spawnUP;
    public bool HasGoneUp;
    public static bool HasKilledLeader;
    public GameObject stairsDOWN;
    public GameObject spawnDOWN;

    bool upthestairs = false;

    // Start is called before the first frame update

    public void SpawnRoomObjects(int room)
    {
        if (room == 1)
        {
            room1Objects = Instantiate(Room1Objects,new Vector3(), Quaternion.Euler(new Vector3()));
        }
        else if (room == 2)
        {
            room2Objects = Instantiate(Room2Objects, new Vector3(), Quaternion.Euler(new Vector3()));
        }
    }

    public void RespawnRoomObjects(int room)
    {
        if (room == 1)
        {
            Destroy(room1Objects);
        }
        else if (room == 2)
        {
            Destroy(room2Objects);
        }
        SpawnRoomObjects(room);
    }
    void Start()
    {
        TheTaskSctipt = this;
        arrow = GameObject.FindGameObjectWithTag("arrow");
        //arrow.SetActive(false);

        // task 1
        infosteal = GameObject.FindGameObjectWithTag("info");
        basket.SetActive(false);
        DropOfftext.SetActive(false);

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
        //Task 1
        
        //if (isInBuilding)
        //{
        //    rain.SetActive(false);
        //}
        //else
        //{
        //    //rain.SetActive(true);
        //}
        if (hasInfo == true)
        {
            DropOfftext.SetActive(true);
            basket.SetActive(true);
        }
        //if (TaskmanTXTbox.doingTask1 == true || TaskmanTXTbox.doingTask3 == true || TaskmanTXTbox.doingTask2 == true)
        //{
        //    arrow.SetActive(true);
        //}
        //if (TaskmanTXTbox.doingTask1 == false && TaskmanTXTbox.doingTask3 == false && TaskmanTXTbox.doingTask2 == false)
        //{
        //    arrow.SetActive(false);
        //}
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

        //task4
        if(RayCastTwoPointO.LeaderDead == true)
        {
            TaskmanTXTbox.doneTask4 = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //task 1
        if(collision.gameObject.tag == "basket")
        {
            Destroy(basket);
            Destroy(DropOfftext);
            Destroy(moneyText);
        }
        if(collision.gameObject.tag == "DoorOut")
        {
            isInBuilding = false;
        }
        if (collision.gameObject.tag == "DoorIn")
        {
            if (!isInBuilding)
            {
                SpawnRoomObjects(1);
                isInBuilding = true;
                Room = 1;
            }
        }
        if (collision.gameObject.tag == "info" && hasInfo == false)
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
            //leader.SetActive(false);
            Destroy(leader);
            leader.transform.position = Car.car.transform.position;

            LeaderInCar = true;
            dropOff.SetActive(true);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //task 2
        if(collision.gameObject.tag == "DropOff" && LeaderInCar == true)
        {
            //Destroy(leader);
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

        //task 4
        if (collision.gameObject.tag == "stairsUP" && TaskmanTXTbox.doingTask4 == true)
        {
            gameObject.transform.position = spawnUP.transform.position;
            System.Threading.Thread.Sleep(1000);
            Room = 2;
            if (!upthestairs)
            {
                SpawnRoomObjects(2);
                upthestairs = true;
               
            }
        }
        // LATER-- Add for when you kill mob boss
    }
}
