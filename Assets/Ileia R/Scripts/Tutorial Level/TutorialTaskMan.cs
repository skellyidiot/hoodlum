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
    public static bool firstTaskDone = false;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;
    public GameObject gunTxt;
    public GameObject joseTxt;


     void Start()
     {
        firstTask = false;
        firstTaskDone = false;
        gunTxt.SetActive(false);
        joseTxt.SetActive(true);
        RootObjectOfHFactsTextBox.SetActive(false);

        txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "The name's Jose. I'll give you a job, and you do it. " +
            "\nYou ready to help the community now? \n \nPress the corresponding key to answer: \n1.) Yes \n2.) No";
     }

    private void Update()
    {
        if (firstTask == false && tutorialTriggers.enemyCount >= 5)
        {
            if (isTalking == true && Input.GetKeyDown("1"))
            {
                gunTxt.SetActive(true);
                txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Good. Let's get you started. There are five mafia \nmembers around the streets. " +
                    "\n\nGo take them out and come back to me.";
                firstTask = true;
            }
            if (isTalking == true && Input.GetKeyDown("2"))
            {
                SceneManager.LoadScene("basic");
            }
        }

        if(firstTaskDone == true)
        {
            gunTxt.SetActive(false);
            txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "Good job, you're ready to go. Let me know when you \nwanna get going." +
                "\n\n1.) Let's Go \n2.) I'll stay a bit";
            if (isTalking == true && Input.GetKeyDown("1"))
            {
                SceneManager.LoadScene("basic");
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
            joseTxt.SetActive(false);
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
