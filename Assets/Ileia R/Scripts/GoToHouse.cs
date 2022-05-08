using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GoToHouse : MonoBehaviour
{
    public GameObject player;
    public GameObject door;

    public Animator anim;
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
            //anim.Play("fadeOut");
            System.Threading.Thread.Sleep(1000);
            TaskmanTXTbox.doingTask1 = true;
            AllTasks.isInBuilding = true;
            player.transform.position = door.transform.position;
        }
    }
}
