using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;

    public float force = 20f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.HasGunOut == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shooting();
            }
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
    
}
