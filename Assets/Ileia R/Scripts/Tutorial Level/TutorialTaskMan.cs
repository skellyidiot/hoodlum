using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTaskMan : MonoBehaviour
{
    public GameObject player;
    private GameObject textobj;

    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;
    public bool isTalking;


     void Start()
     {
            RootObjectOfHFactsTextBox.SetActive(false);

            txt.GetComponentInChildren<UnityEngine.UI.Text>().text = "I am Jose, I will give you tasks, and you do them, are you ready to help the community now? \n \nPress the corresponding key to answer: \n1.) Yes \n2.) No";
     }

    private void Update()
    {
        if (isTalking == true && Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("basic");
        }
        if (isTalking == true && Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("TutorialLevel");
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
