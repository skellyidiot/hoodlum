using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight2 : MonoBehaviour
{

    public GameObject player;


    public Vector3 eUp;
    public Vector2 toTarget;
    public float angle;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance >= 10)
        {
            eUp = transform.up;
            toTarget = player.transform.position - transform.position;
            angle = Mathf.Acos(Vector2.Dot(toTarget, transform.up) / (toTarget.magnitude * transform.up.magnitude)) * Mathf.Rad2Deg;
        }
        
    }
}
