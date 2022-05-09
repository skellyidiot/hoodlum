using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Owner;
    public float Damage = 20;
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PhysicsObjects")
        {
            collision.gameObject.GetComponent<PhysicsHitObject>().Hit(100, transform.position, transform.eulerAngles.z);
        }
    }

}
