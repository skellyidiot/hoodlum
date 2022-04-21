using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class icon : MonoBehaviour
{
    public Sprite[] Icons;
    private GameObject Iconject;
    public int Icon = 0;
    // Start is called before the first frame update
    void Start()
    {
        Iconject = transform.GetChild(0).gameObject;
        Iconject.GetComponent<SpriteRenderer>().sprite = Icons[Icon];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
