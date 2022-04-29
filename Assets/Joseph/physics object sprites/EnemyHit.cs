using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : PhysicsHitObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Hit(float force, Transform form)
    {
        base.Hit(force, form);
        print("make hp down");
        print("falldown");
    }
}
