using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenDead : MonoBehaviour
{

    public GameObject player;
    public GameObject SpawinInBuilding;


    public GameObject safe;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        SpawinInBuilding = GameObject.FindGameObjectWithTag("BuildingSpawn");

    }


    public void Dead()
    {
        RayCastTwoPointO.encountered.Clear();
        AllTasks.TheTaskSctipt.UnCounter();
        player.transform.position = SpawinInBuilding.transform.position;
        AllTasks.TheTaskSctipt.RespawnRoomObjects(AllTasks.TheTaskSctipt.Room);
    }

}
