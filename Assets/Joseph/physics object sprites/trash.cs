using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    public enum TRASHES { napkin,cig,burger,cup,turd,magazine,ketchup,plate,sus,arm,coal,weed,shoe,powder}
    public  Sprite[] sprites = new Sprite[14];
    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GetTrashSprite(GetTrash());
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
            print(rng);
            TRASHES TheTrash = (TRASHES)rng1;
            if (rng <= GetTrashRandom((TheTrash)))
            {
                return TheTrash;
            }
            print("Didnt get it :(");
        }
        
    }
}
