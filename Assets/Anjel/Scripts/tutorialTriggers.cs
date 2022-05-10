using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialTriggers : MonoBehaviour
{
    public static int enemyCount;

    GameObject bad;
    SpriteRenderer sr;

    public GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.enabled = false;

        enemyCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (TutorialTaskMan.firstTask == true)
        {
            sr.enabled = true;
        }

        if (enemyCount <= 0)
        {
            Debug.Log(TutorialTaskMan.firstTaskDone);
            TutorialTaskMan.firstTaskDone = true;
            Debug.Log(TutorialTaskMan.firstTaskDone);
        }

        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("kill");
            Destroy(this.gameObject);
            enemyCount--;
            Debug.Log(enemyCount);
        }
    }
}
