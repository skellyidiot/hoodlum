using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapcam : MonoBehaviour
{
    public GameObject player;

    public float px;
    public float py;
    public float pz;
    // Start is called before the first frame update
    void Start()
    {
        px = player.transform.rotation.x;
        py = player.transform.rotation.y;
        pz = player.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(-px, -py, -pz);

    }
}
