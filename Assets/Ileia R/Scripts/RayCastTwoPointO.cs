using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTwoPointO : MonoBehaviour
{
    public LayerMask layer;

    public Transform firePoint;
    public GameObject bulletprefab;
    public GameObject muzzle;

    public float force = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 7f);

        if (hit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up)* 7f, Color.green);
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Player")
            {
                gameObject.GetComponent<FollowPath>().enabled = false;
                Debug.Log(hit.collider.gameObject.tag);
                Shoot();
            }
            else
            {
                gameObject.GetComponent<FollowPath>().enabled = true;
            }
        }
        
    }
    
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
        Debug.Log("Shooting");
    }
}
