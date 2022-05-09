using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AllTasks.TheTaskSctipt.infosteal = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
