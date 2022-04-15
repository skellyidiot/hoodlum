using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarTutorialText : MonoBehaviour
{
    public static bool isInCar;
    public GameObject car;
    public GameObject thing;
    private void Start()
    {
        isInCar = false;
    }
    private void Update()
    {
        isInCar = Car.isDriving;

        if (isInCar)
        {
            Destroy(thing);
        }
    }
}
