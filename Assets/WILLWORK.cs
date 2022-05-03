using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WILLWORK : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public JimsCrazySolution jim;
    public Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            jim.GetComponent<JimsCrazySolution>().enabled = false;
            transform.position = this.transform.position;
        }
        //}else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    jim.GetComponent<JimsCrazySolution>().enabled = true;
        //}
    }
}
