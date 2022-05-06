using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEnemy : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;

    [SerializeField]
    float agroRange;

    private void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            this.GetComponent<FollowPath>().enabled = false;
            Debug.Log("Player in sight");
        }
        else
        {
            this.GetComponent<FollowPath>().enabled = true;
        }
    }
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player")){
                //do stuff
                val = true;
                //this.GetComponent<FollowPath>().enabled = false;
                Debug.Log("Player in sight IN F");
            }
            else
            {
                val = false;
                Debug.Log("Nothing IN F ");
            }
        }
        return val;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("HIT WITH BULLET!");
            Destroy(gameObject);
        }
    }
}
