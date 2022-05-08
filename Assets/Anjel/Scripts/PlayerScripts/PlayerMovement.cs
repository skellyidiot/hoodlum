using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    bool gothit = false;

    public float moveSpeed = 5f;
    public float stamina = 10;
    public bool IsRunning = false;
    public static bool HasGunOut = false;
    public GameObject HPBar;
    public GameObject StaminaWheel;

    public float movmentdeg = 0;
    public Vector2 movementdif;

    public static float Hp = 100;

    public bool resting = false;

    const float RUNSPEED = 10;
    const float WALKSPEED = 5;

    public Rigidbody2D rb;
    public Camera cam;
    Animator ani;
    SpriteRenderer sr;

    Vector2 movement;
    Vector2 mousePos;

    public static float TimeSinceHit;
    public bool isRegenHealth;
    
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        ani = gameObject.GetComponent<Animator>();
        HPBar.GetComponent<Slider>().value = Hp / 100;

        TimeSinceHit = 0;
    }

    // Update is called once per frame
    void Die()
    {
        print("Dead");
        Destroy(gameObject);
    }
    public void Hit(int damage)
    {
        Hp -= damage;
        HPBar.GetComponent<Slider>().value = Hp / 100;
        //print(Hp/100);
        if (Hp <= 0)
        {
            Die();
        }
    }
    void AddHp()
    {
        //if(Hp < 100)
        //{
        //    StartCoroutine(WaitBeforeAdd());
        //    Hp += 1;
        //    HPBar.GetComponent<Slider>().value = Hp / 100;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            Hit(20);
            Destroy(collision.gameObject);
            gothit = true;
            //Hp += Time.deltaTime;

            //TimeSinceHit = 0;
            //TimeSinceHit += Time.deltaTime;
        }
    }
    void Update()
    {
        Debug.Log(Hp);
       if(Hp > 100)
       {
            Hp = 100;
            gothit = false;
       }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (gothit)
        {
            //StartCoroutine(WaitBeforeAdd());
            AddHp();
        }

        //if (Input.GetKeyDown("h"))
        //{
        //Debug.Log(TimeSinceHit);
        //}
        //sprinting dont work is lame

        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina >= 0 && resting == false)
        {
            IsRunning = true;
           moveSpeed = RUNSPEED;
           ani.speed = 2;

        }
        if (IsRunning == true)
        {
            stamina -= 0.8f * Time.deltaTime;
            StaminaWheel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || stamina <= 0)
        {
           IsRunning = false;
            moveSpeed = WALKSPEED;
            ani.speed = 1;
            
        }
        if (stamina <= 0)
        {
            resting = true;
            StaminaWheel.GetComponent<Image>().color = Color.red;
            
        }
        if (stamina >= 10)
        {

            StaminaWheel.SetActive(false);
        }
        if (resting && stamina >= 2.5)
        {
            resting = false;
            StaminaWheel.GetComponent<Image>().color = Color.green;
        }
        if (IsRunning == false && stamina < 10)
        {
            if (resting)
            {
                stamina += 0.5f * Time.deltaTime;
            }
            else
            {
                stamina += 0.8f * Time.deltaTime;
            }
            
        }
        StaminaWheel.GetComponent<Image>().fillAmount = stamina / 10;

        
        
        
         StartCoroutine(WaitBeforeAdd());
        

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");

        mousePos = Input.mousePosition;
        mousePos -= new Vector2(Screen.width / 2, Screen.height / 2);
        //print(mousePos.normalized);

        ani.SetFloat("Horizontal", movement.x);
        ani.SetFloat("Vertical", movement.y);

        if (movement != new Vector2())
        {
            ani.SetBool("Moving", true);
        }
        else
        {
            ani.SetBool("Moving", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ani.SetBool("HasGunOut", true);
            HasGunOut = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ani.SetBool("HasGunOut", false);
            HasGunOut = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 m1 = transform.position;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        movementdif = transform.position - m1;
        movmentdeg = Mathf.Atan2(movementdif.y, movementdif.x) * Mathf.Rad2Deg - 90f;

        Vector2 lookDir = mousePos.normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    //private IEnumerator RegainHealthOverTime()
    //{
    //    while(true)
    //    {
    //        if(Hp < 100)
    //        {
    //            Debug.Log("IS REGAINING HEALTH AND IS AT:" + Hp);
    //            yield return new WaitForSeconds(1);
    //            Hp += 1;
    //        }
    //        else
    //        {
    //            yield return null;
    //        }
            
    //    }
    //}
    IEnumerator WaitBeforeAdd()
    {
        if (Hp < 100)
        {
            Hp += 1;
            yield return new WaitForSeconds(2);
            HPBar.GetComponent<Slider>().value = Hp / 100;
            yield return new WaitForSeconds(2);
        }
    }
}
