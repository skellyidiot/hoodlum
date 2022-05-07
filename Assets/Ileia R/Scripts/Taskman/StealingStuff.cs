using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StealingStuff : MonoBehaviour
{
    public Text txt;
    public GameObject RootObjectOfHFactsTextBox;

    public int money = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //RootObjectOfHFactsTextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(TaskmanTXTbox.doingTask1 == true)
        //{
        //    RootObjectOfHFactsTextBox.SetActive(true);
        //}
        //if(TaskmanTXTbox.doneTask1 == true)
        //{
        //    RootObjectOfHFactsTextBox.SetActive(false);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            int randomMoney = Random.Range(50, 1000);
            Money.money += randomMoney;
            Debug.Log(randomMoney);
            Money.txt.text = "$" + Money.money;
        }
    }
}
