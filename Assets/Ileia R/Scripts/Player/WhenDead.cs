using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenDead : MonoBehaviour
{
    public GameObject player;
    public GameObject SpawinInBuilding;

    public GameObject enemy1;
    public GameObject enemy1Spawn;

    public GameObject enemy2;
    public GameObject enemy2Spawn;

    public GameObject safe;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpawinInBuilding= GameObject.FindGameObjectWithTag("BuildingSpawn");
        safe = GameObject.FindGameObjectWithTag("info");

        enemy1Spawn.transform.position = enemy1.transform.position;

        enemy2Spawn.transform.position = enemy2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isDead)
        {
            player.transform.position = SpawinInBuilding.transform.position;

            enemy1.transform.position = enemy1Spawn.transform.position;
            enemy2.transform.position = enemy2Spawn.transform.position;
            PlayerMovement.isDead = false;
        }
    }
}
