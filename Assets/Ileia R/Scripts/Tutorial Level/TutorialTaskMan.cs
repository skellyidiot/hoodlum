using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTaskMan : MonoBehaviour
{
    public GameObject player;
    private GameObject textobj;
    public static bool firstTask = false;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;


     void Start()
     {
        firstTask = false;
        RootObjectOfHFactsTextBox.SetActive(false);

        txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "The name's Jose. I'll give you a job, and you do it. " +
            "\nYou ready to help the community now? \n \nPress the corresponding key to answer: \n1.) Yes \n2.) No";
     }

    private void Update()
    {
        if (firstTask == false)
        {
            if (isTalking == true && Input.GetKeyDown("1"))
            {
                txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Good. Let's get you started. There are five mafia \nmembers around the streets. " +
                    "Go take them out. Got it? \n \n1.) Yes \n2.) No";

                if (isTalking == true && Input.GetKeyDown("1"))
                {
                    firstTask = true;
                }
                if (isTalking == true && Input.GetKeyDown("2"))
                {
                    SceneManager.LoadScene("basic");
                }
            }
            if (isTalking == true && Input.GetKeyDown("2"))
            {
                SceneManager.LoadScene("basic");
            }
        }

        if(tutorialTriggers.firstTaskDone == true)
        {
            txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Good job, you're ready to go. \n1.) Start \n2.) No";
            if (isTalking == true && Input.GetKeyDown("1"))
            {
                firstTask = true;
            }
            if (isTalking == true && Input.GetKeyDown("2"))
            {
                SceneManager.LoadScene("basic");
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
