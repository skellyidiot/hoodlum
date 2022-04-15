using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskmanTXTbox : MonoBehaviour
{
    public GameObject player;
    int curtext = 0;
    private GameObject textobj;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;

    public static bool doingTask1;
    public static bool doingTask2;
    public static bool doingTask3;

    public static bool doneTask1;
    public static bool doneTask2;
    public static bool doneTask3;

    private string Text1 = "Do whatever you want";
    private string Text2 = "Do whatever I want";
    private string Text3 = "leave";

    // Start is called before the first frame update
    void Start()
    {
        RootObjectOfHFactsTextBox.SetActive(false);

        txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Hey, I am task man, which task do you want to do? \n 1.) Go infiltrate the leaders house and steal money from the safe \n 2.) Drive leader to his destination \n 3.) Go from ___ to ___ in 60 seconds";
    }

    void Update()
    {

        if (isTalking == true)
        {
            if (Input.GetKeyDown("1") && doneTask1 != true)
            {
                doingTask1 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
            }
            if (Input.GetKeyDown("2") && doneTask2 != true)
            {
                doingTask2 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
            }
            if (Input.GetKeyDown("3") && doneTask3 != true)
            {
                doingTask3 = true;
                RootObjectOfHFactsTextBox.SetActive(false);
            }
        }
        if(doneTask1 == true)
        {
            doingTask1 = false;
        }
        if (doneTask2 == true)
        {
            doingTask2 = false;
        }
        if (doneTask3 == true)
        {
            doingTask3 = false;
        }

        if (doneTask1 == true && doneTask2 == false && doneTask3 == false && doingTask2 == false && doingTask3 == false)
        {
            txt.text = "good job doing task 1, now pick one of these tasks \n 2.) Drive leader to his destination \n 3.) Go from ___ to ___ in 60 seconds";
        }
        if (doneTask1 == true && doneTask2 == true && doneTask3 == false && doingTask3 == false)
        {
            txt.text = "good job doing task 1 and two, you can only do this task: \n 3.) Go from ___ to ___ in 60 seconds";
        }
        if (doneTask1 == false && doneTask2 == true && doneTask3 == false && doingTask3 == false && doingTask1 == false)
        {
            txt.text = "good job doing task 2, you can only do this task: \n 1.) Go infiltrate the leaders house and steal money from the safe   \n 3.) Go from ___ to ___ in 60 seconds";
        }
        if (doneTask1 == true && doneTask3 == true && doneTask2 != true && doingTask2 != true)
        {
            txt.text = "Good job doing task 1 and task 3, now do this task: \n 2.) Drive leader to his destination)";
        }
        if(doneTask2 == true && doneTask3 == true && doneTask1 != true && doingTask1 != true)
        {
            txt.text = "Good job doing task 2 and task 3, now do this task: \n 1.) Go infiltrate the leaders house and steal money from the safe  ";
        }
        if (doneTask2 != true && doneTask3 == true && doneTask1 != true && doingTask1 != true && doingTask2 != true)
        {
            txt.text = "Good job doing task 3, now do this task: \n 1.) Go infiltrate the leaders house and steal money from the safe  \n 2.) Drive leader to his destination)";
        }
        if(doneTask1 == true && doneTask2 == true && doneTask3 == true)
        {
            txt.text = "Good job you are done!";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && doingTask1 != true && doingTask2 != true && doingTask3 != true)
        {
            RootObjectOfHFactsTextBox.SetActive(true);
            isTalking = true;
        }
        if (collision.gameObject.tag != "Player")
        {
            RootObjectOfHFactsTextBox.SetActive(false);
            isTalking = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        RootObjectOfHFactsTextBox.SetActive(false);
        isTalking = false;
    }
}
