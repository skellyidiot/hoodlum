using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public Vector3 PreviousFramePosition = Vector3.zero; // Or whatever your initial position is
    public float Speeds = 0f;

    void Update()
    {
        // All the update stuff
        // ...
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        Speeds = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;

        Debug.Log(Speeds);
    }

}
