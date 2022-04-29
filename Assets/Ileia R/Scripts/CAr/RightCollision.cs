using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D collision)
    {
        Car.isCollidedLeft = true;
    }
    private void OnTriggerExit2D(Collision2D collision)
    {
        Car.isCollidedLeft = false;
    }
}
