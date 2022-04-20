using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTriggers : MonoBehaviour
{
    public static bool firstTaskDone = false;
    public static int enemyCount = 5;

    GameObject bad;
    SpriteRenderer sr;

    public GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        firstTaskDone = false;
        sr = this.GetComponent<SpriteRenderer>();
        sr.enabled = false;

        enemyCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (TutorialTaskMan.firstTask == true)
        {
            sr.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("kill");
            Destroy(gameObject);
            enemyCount--;
        }
    }
}
