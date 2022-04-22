using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    public enum TRASHES { napkin,cig,burger,cup,turd,magazine,ketchup,plate,sus,arm,coal,weed,shoe,powder}
    public static Sprite[] sprites;
    // Start is called before the first frame update
    public static Sprite GetTrashSprite(TRASHES tr)
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
    public static TRASHES GetTrash()
    {
        float rng = Random.RandomRange(0, 1);
        print(rng);
        return TRASHES.coal

    }
}
