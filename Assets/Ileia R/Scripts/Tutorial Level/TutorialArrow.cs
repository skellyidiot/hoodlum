using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialArrow : MonoBehaviour
{
    public float speed = 2f;

    public GameObject car;

    public GameObject jose;

    // Update is called once per frame
    void Update()
    {
        if (CarTutorialText.isInCar == false && Car.hasbeenincar == false)
        {
            Vector3 vectorToTarget = transform.position - car.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        if(Car.hasbeenincar == true)
        {
            //Debug.Log("HASBEENINCAR--------------------------------------------------------");
            Vector3 vectorToTarget = transform.position - jose.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
}
