using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkinTone : MonoBehaviour
{
    public SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        int random = Random.Range(0, 5);
        if (random == 1) renderer.color = new Color(0.5529412f, 0.3333333f, 0.1411765F);
        if (random == 2) renderer.color = new Color(0.7764706f, 0.5254902f, 0.2588235f);
        if (random == 3) renderer.color = new Color(0.8784314f, 0.6745098f, 0.4117647f);
        if (random == 4) renderer.color = new Color(0.945098f, 0.7607843f, 0.4901961f);
        if (random == 0) renderer.color = new Color(1f, 0.8588235f, 0.6745098f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
