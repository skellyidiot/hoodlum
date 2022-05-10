using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;


public class TaskmanTXTbox : MonoBehaviour
{
    public GameObject spawnNextToMan;


    public GameObject player;
    int curtext = 0;
    private GameObject textobj;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;
    public Animator anim;

    public static bool doingTask1;
    public static bool doingTask2;
    public static bool doingTask3;
    public static bool doingTask4;

    public static bool doneTask1 = false;
    public static bool doneTask2 = false;
    public static bool doneTask3 = false;
    public static bool doneTask4 = false;

    private string Text1 = "Do whatever you want";
    private string Text2 = "Do whatever I want";
    private string Text3 = "leave";

    public AudioClip JoseTheme;

    // Start is called before the first frame update
    void Start()
    {
        RootObjectOfHFactsTextBox.SetActive(false);

        txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Hey, I am task man, which task do you want to do? Select the corresponding key" +
            "\n 1.) Go infiltrate the mob boss's house and steal money and items to give back to the people he stole from" +
            " \n 2.) Pose as the Mob boss's driver and drive him to his destination and listen to his conversation to find \nout where he keeps the rest of his money\n 3.) I have a bunch of food, give them the food bank, and get there before it gets cold in 60 seconds";
    }

    void Update()
    {
        //Debug.Log(doingTask4 + "=====================================================");
        if (Input.GetKeyDown("l"))
        {
            doneTask1 = true;
            doneTask2 = true;
            doneTask3 = true;
            //doingTask4 = false;

            //System.Threading.Thread.Sleep(1000);
            //AllTasks.isInBuilding = true;
            //player.transform.position = spawnNextToMan.transform.position;
        }
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
            if(Input.GetKeyDown("4") && doneTask1 == true && doneTask2 == true && doneTask3 == true)
            {
                doingTask4 = true;
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
        if(doneTask4 == true)
        {
            doingTask4 = false;
        }

        if (doneTask1 == true && doneTask2 == false && doneTask3 == false && doingTask2 == false && doingTask3 == false)
        {
            //do stuff for task 2 and 3 
            txt.text = "good job doing task 1, now pick one of these tasks \n2.) Pose as the Mob boss's driver and drive him to his destination and listen to his conversation to find \nout where he keeps the rest of his mone \n 3.) I have a bunch of food, give them the food bank, and get there before it gets cold in 60 secondss";
        }
        if (doneTask1 == true && doneTask2 == true && doneTask3 == false && doingTask3 == false)
        {
            //do stuff for task 3 
            txt.text = "good job doing task 1 and 2, you can only do this task: \n 3.) I have a bunch of food, give them the food bank, and get there before it gets cold in 60 seconds";
        }
        if (doneTask1 == false && doneTask2 == true && doneTask3 == false && doingTask3 == false && doingTask1 == false)
        {
            //do stuff for task 1 and 3  
            txt.text = "good job doing task 2, you can only do this task: \n  1.) Go infiltrate the mob boss's house and steal money and items to give back to the people he stole from \n 3.) I have a bunch of food, give them the food bank, and get there before it gets cold in 60 seconds";
        }
        if (doneTask1 == true && doneTask3 == true && doneTask2 != true && doingTask2 != true)
        {
            //do stuff for task 2 
            txt.text = "Good job doing task 1 and task 3, now do this task: \n 2.) Pose as the Mob boss's driver and drive him to his destination and listen to his conversation to find \nout where he keeps the rest of his money";
        }
        if(doneTask2 == true && doneTask3 == true && doneTask1 != true && doingTask1 != true)
        {
            //do stuff for task 1 
            txt.text = "Good job doing task 2 and task 3, now do this task: \n  1.) Go infiltrate the mob boss's house and steal money and items to give back to the people he stole from ";
        }
        if (doneTask2 != true && doneTask3 == true && doneTask1 != true && doingTask1 != true && doingTask2 != true)
        {
            //do stuff for task 1 and 2
            txt.text = "Good job doing task 3, now do this task: \n 1.) Go infiltrate the mob boss's house and steal money and items to give back to the people he stole from \n 2.) Pose as the Mob boss's driver and drive him to his destination and listen to his conversation to find \nout where he keeps the rest of his money";
        }
        if (doneTask1 == true && doneTask2 == true && doneTask3 == true && doneTask4 == false)
        {
            //do stuff for task 4 
            txt.text = "Jeez, you've come a long way! Now for the main challenge: \n 4.) Go back to the mob boss's house and kill him in his office upstairs";
        }
        if (doneTask1 == true && doneTask2 == true && doneTask3 == true &&  doneTask4 == true)
        {
            txt.text = "Good job you are done!";
            anim.Play("fadeOut");
            System.Threading.Thread.Sleep(1000);
            SceneManager.LoadScene("win");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && doingTask1 != true && doingTask2 != true && doingTask3 != true)
        {
            RootObjectOfHFactsTextBox.SetActive(true);
            isTalking = true;
            Music.ChangeMusic(JoseTheme);
        }
        if (collision.gameObject.tag != "Player")
        {
            RootObjectOfHFactsTextBox.SetActive(false);
            isTalking = false;
            Music.ChangeMusic(Music.MapMusic);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        RootObjectOfHFactsTextBox.SetActive(false);
        isTalking = false;
        Music.ChangeMusic(Music.MapMusic);
    }
}
