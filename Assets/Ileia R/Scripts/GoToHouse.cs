using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHouse : MonoBehaviour
{
    public GameObject player;
    public GameObject door;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("BuildingSpawn");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h"))
        {
            TaskmanTXTbox.doingTask1 = true;
            AllTasks.isInBuilding = true;
            player.transform.position = door.transform.position;
        }
    }
}
