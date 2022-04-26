using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : PhysicsHitObject
{
    float time = 0;
    public GameObject Trash;
    // Start is called before the first frame update

    // Update is called once per frame
    public override void Hit()
    {
        base.Hit();
        SpawnTrash();
    }
    void SpawnTrash()
    {
        int TrashAmnt = Random.RandomRange(5, 20);
        for (int i = 0; i < TrashAmnt; i++)
        {
            GameObject e = Instantiate(Trash,transform.position,transform.rotation);
            e.GetComponent<trash>().Begin();
        } 
    }
}
