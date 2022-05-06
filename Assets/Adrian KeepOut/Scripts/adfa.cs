using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adfa : MonoBehaviour
{
    public List<Transform> patrolPts = new List<Transform>();
    public GameObject NPC;
    public static int NPCCOUNT = 150;
    public static int Spot;
    public int MAXNPC;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject NPC in GameObject.FindGameObjectsWithTag("people"))
        {

            patrolPts.Add(NPC.transform);
        }

        for (int i = 0; i < NPCCOUNT; i++)
        {
            Debug.Log(i + "+>>> " + patrolPts[i].transform.position);
            Instantiate(NPC, patrolPts[i].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        while(NPCCOUNT <= 150)
        
        {
            Instantiate(NPC, patrolPts[Spot].transform.position, Quaternion.identity);
            Spot++;
            NPCCOUNT++;
            
        }
        if (Spot == 150) Spot = 0;
        //Debug.Log(GameObject.FindGameObjectsWithTag("NPC").ToString());
    }
}
