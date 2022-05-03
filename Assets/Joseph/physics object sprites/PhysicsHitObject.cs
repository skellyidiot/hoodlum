using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHitObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Hit(float force, Vector3 pos, float dir)
    {
        print("hit");
        transform.eulerAngles = new Vector3 (0,0,dir);
    }
}
