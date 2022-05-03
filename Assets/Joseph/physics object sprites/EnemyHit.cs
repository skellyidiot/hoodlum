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
    public override void Hit(float force, Vector3 pos, float dir)
    {
        base.Hit(force, pos, dir);
        print("make hp down");
        print("falldown");
    }
}
