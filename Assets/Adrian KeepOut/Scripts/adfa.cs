using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adfa : MonoBehaviour
{
    public List<Transform> patrolPts = new List<Transform>();
    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject NPC in GameObject.FindGameObjectsWithTag("people"))
        {

            patrolPts.Add(NPC.transform);
        }

        for (int i = 0; i < 25; i++)
        {
            Debug.Log(i + "+>>> " + patrolPts[i].transform.position);
            Instantiate(NPC, patrolPts[i].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
