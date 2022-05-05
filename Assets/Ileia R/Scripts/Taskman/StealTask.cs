using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealTask : MonoBehaviour
{
    public float time = 0.0f;
    public float timeToShow = 1f;
    public bool isShowing;
    public GameObject transition;

    public GameObject SpawnINBUILDING;
    public GameObject SpawnNOTINBUILDING;

    public bool isInBuilding;

    public bool hasAlreadyGoneIn;

    public GameObject arrow;
    public GameObject arrowPointAt;

    // Start is called before the first frame update
    void Start()
    {
        arrowPointAt = GameObject.FindGameObjectWithTag("DoorIn");

        transition.SetActive(false);
        isShowing = false;

        isInBuilding = false;
        hasAlreadyGoneIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DoorIn" && hasAlreadyGoneIn == false && isInBuilding == false && TaskmanTXTbox.doingTask1 == true && Car.isDriving == false)
        {
            isInBuilding = true;

            gameObject.transform.position = SpawnINBUILDING.transform.position;
        }

        if(collision.gameObject.tag == "DoorOut" && isInBuilding == true && AllTasks.hasInfo == true)
        {
            isInBuilding = false;
            hasAlreadyGoneIn = true;
            gameObject.transform.position = SpawnNOTINBUILDING.transform.position;
            TaskmanTXTbox.doneTask1 = true;
        }
    }
    
}
