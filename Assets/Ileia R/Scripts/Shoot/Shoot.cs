using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public GameObject muzzle;

    public float force = 20f;

    public bool hasBeenShot = false;
    public float time = 0.0f;
    public float interpolationPeriod = 0.0001f;
    public AudioClip GunSHot;
    private void Start()
    {
        muzzle.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hasBeenShot);

        if (PlayerMovement.HasGunOut == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GetComponent<AudioSource>().clip = GunSHot;
                GetComponent<AudioSource>().Play();
                hasBeenShot = true;
                Shooting();
                //muzzle.SetActive(true);
                //time += Time.deltaTime;
            }
        }
        //if(PlayerMovement.HasGunOut == false)
        //{
        //    muzzle.SetActive(false);
        //}
        //if (time >= interpolationPeriod)
        //{
        //    Debug.Log("STOP!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //    //hasBeenShot = false;
        //    muzzle.SetActive(false);
        //    time = 0;
        //}
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
    
}
