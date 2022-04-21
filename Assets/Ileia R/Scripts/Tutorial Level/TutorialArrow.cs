using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialArrow : MonoBehaviour
{
    public float speed = 2f;

    public GameObject car;
    public GameObject jose;

    SpriteRenderer sr;
    MafiaTemp targetObject;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SearchNearest();
        //points to car
        if (CarTutorialText.isInCar == false && Car.hasbeenincar == false)
        {
            Vector3 vectorToTarget = transform.position - car.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        //points to jose
        if (Car.hasbeenincar == true && TutorialTaskMan.firstTask == false)
        {
            Vector3 vectorToTarget = transform.position - jose.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        //points to nearest target
        if (TutorialTaskMan.firstTaskDone == false && TutorialTaskMan.firstTask == true)
        {
            SearchNearest();
            Vector3 vectorToTarget = transform.position - targetObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        //points to jose after killing mafia
        if (TutorialTaskMan.firstTaskDone == true && tutorialTriggers.enemyCount==0)
        {
            Vector3 vectorToTarget = transform.position - jose.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }

    private void SearchNearest()
    {
        float distToTarget = Mathf.Infinity;
        MafiaTemp targetEnemy = null;
        MafiaTemp[] allEnemies = GameObject.FindObjectsOfType<MafiaTemp>();

        foreach (MafiaTemp currentEnemy in allEnemies )
        {
            float distToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if ( distToEnemy < distToTarget)
            {
                distToTarget = distToEnemy;
                targetEnemy = currentEnemy;
                targetObject = targetEnemy;
            }
        }


        //Debug.DrawLine(this.transform.position, targetEnemy.transform.position);
        

    }

}
