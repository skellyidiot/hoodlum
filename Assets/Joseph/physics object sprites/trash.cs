using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    float Timer = 0;
    bool f = false;
    public enum TRASHES { napkin,cig,burger,cup,turd,magazine,ketchup,plate,sus,arm,coal,weed,shoe,powder}
    public  Sprite[] sprites = new Sprite[14];
    public bool despawn = true;
    SpriteRenderer sr;
    // Start is called before the first frame update
    public void Begin()
    {
        sr = GetComponent<SpriteRenderer>();
        float rng = Random.RandomRange(-22.5f, 22.5f);
        GetComponent<Rigidbody2D>().angularVelocity = rng * 5;
        print(transform.rotation.eulerAngles.z);
        float brot = -transform.rotation.eulerAngles.z + rng;
        transform.eulerAngles = new Vector3(0, 0, rng + brot);
        float rngvel = Random.RandomRange(160f, 320f);
        print(transform.forward * rngvel);
        GetComponent<Rigidbody2D>().AddForce(transform.up * rngvel);
        GetComponent<SpriteRenderer>().sprite = GetTrashSprite(GetTrash());
        f = true;
    }
    public void Update()
    {
        if (f && despawn)
        {
            Timer += Time.deltaTime;
            if (Timer > 1)
            {
                sr.color = new Color(1, 1, 1, sr.color.a - 0.001f);
            }
            if (Timer > 5)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
    public  Sprite GetTrashSprite(TRASHES tr)
    {
        switch (tr)
        {
            case TRASHES.napkin:
                return sprites[0];
            case TRASHES.cig:
                return sprites[1];
            case TRASHES.burger:
                return sprites[2];
            case TRASHES.cup:
                return sprites[3];
            case TRASHES.turd:
                return sprites[4];
            case TRASHES.magazine:
                return sprites[5];
            case TRASHES.ketchup:
                return sprites[6];
            case TRASHES.plate:
                return sprites[7];
            case TRASHES.sus:
                return sprites[8];
            case TRASHES.arm:
                return sprites[9];
            case TRASHES.coal:
                return sprites[10];
            case TRASHES.weed:
                return sprites[11];
            case TRASHES.shoe:
                return sprites[12];
            case TRASHES.powder:
                return sprites[13];
        }
        return sprites[0];
    }
    public float GetTrashRandom(TRASHES tr)
    {
        switch (tr)
        {
            case TRASHES.napkin:
                return 0.8f;
            case TRASHES.cig:
                return 0.9f;
            case TRASHES.burger:
                return 0.6f;
            case TRASHES.cup:
                return 0.5f;
            case TRASHES.turd:
                return 0.5f;
            case TRASHES.magazine:
                return 0.2f;
            case TRASHES.ketchup:
                return 0.5f;
            case TRASHES.plate:
                return 0.5f;
            case TRASHES.sus:
                return 0.000000000001f;
            case TRASHES.arm:
                return 0.2f;
            case TRASHES.coal:
                return 0.7f;
            case TRASHES.weed:
                return 0.5f;
            case TRASHES.shoe:
                return 0.7f;
            case TRASHES.powder:
                return 0.3f;
        }
        return 0;
    }

    public TRASHES GetTrash()
    {
        while (true) {
            int rng1 = Random.Range(0, 13);

            float rng = Random.Range(0f, 1f);
            TRASHES TheTrash = (TRASHES)rng1;
            if (rng <= GetTrashRandom((TheTrash)))
            {
                return TheTrash;
            }
        }
        
    }
}
