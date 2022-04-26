using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : PhysicsHitObject
{
    Animator anim;
    float time = 0;
    public GameObject Trash;
    public bool gothit = false;
    float Timer = 0;
    SpriteRenderer sr;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (gothit)
        {
            Timer += Time.deltaTime;
            if (Timer > 10)
            {
                sr.color = new Color(1, 1, 1, sr.color.a - 0.001f);
            }
            if (Timer > 15)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public override void Hit()
    {
        if (gothit != true)
        {
            base.Hit();
            anim.SetBool("hit", true);
            gothit = true;
            StartCoroutine(Wait());
            SpawnTrash();
            
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }
    void SpawnTrash()
    {
        int TrashAmnt = Random.RandomRange(10, 30);
        for (int i = 0; i < TrashAmnt; i++)
        {
            GameObject e = Instantiate(Trash,transform.position,transform.rotation);
            e.GetComponent<trash>().Begin();
        } 
    }
}
