using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour
{
    public GameObject obj0, obj1, obj2, obj3;
    private Vector3 endposition1 = new Vector3(-11, 0, -11);
    private Vector3 startposition1 = new Vector3(0, 0, -8);
    private float desiredDuration = 3f;
    private float elapsedTime;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startposition1;

        
    }

    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageCompete = elapsedTime / desiredDuration;




        Vector3 sp2 = endposition1;
        Vector3 ep2 = new Vector3(-14, 0, -2);
        Vector3 sp3 = ep2;
        Vector3 ep3 = new Vector3(0, 0, 0);
        Vector3 sp4 = ep3;
        Vector3 ep4 = startposition1;
        if (counter == 0)
        {

            Debug.Log(transform.position);
            StartCoroutine(Point1());
            counter++;
        }
        if (counter == 1)
        {

            Debug.Log(transform.position);
            StartCoroutine(Point2());
            counter++;
        }
        if (counter == 2)
        {

            Debug.Log(transform.position);
            StartCoroutine(Point3());
            counter++;
        }
        if (counter == 3)
        {
            StartCoroutine(Point4());
            Debug.Log(transform.position);
            counter++;
        }
        if (counter == 4)
        {
            counter = 0;
        }
        IEnumerator Point1()
        {
            transform.position = Vector3.Lerp(startposition1, endposition1, Mathf.SmoothStep(0, 1, percentageCompete));
            yield return new WaitForSeconds(3f);
            StartCoroutine(Point2());
        }
        IEnumerator Point2()
        {
            transform.position = Vector3.Lerp(sp2, ep2, Mathf.SmoothStep(0, 1, percentageCompete));
            yield return new WaitForSeconds(6f);
            StartCoroutine(Point3());
        }
        IEnumerator Point3()
        {
            transform.position = Vector3.Lerp(sp3, ep3, Mathf.SmoothStep(0, 1, percentageCompete));
            yield return new WaitForSeconds(9f);
            StartCoroutine(Point4());
        }
        IEnumerator Point4()
        {
            transform.position = Vector3.Lerp(sp4, ep4, Mathf.SmoothStep(0, 1, percentageCompete));
            yield return new WaitForSeconds(12f);
            StartCoroutine(Point1());
        }




    }


}
