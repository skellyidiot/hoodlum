using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D collision)
    {
        Car.isCollidedRight = true;
    }
    private void OnTriggerExit2D(Collision2D collision)
    {
        Car.isCollidedRight = false;
    }
}
