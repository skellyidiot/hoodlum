using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Car : MonoBehaviour
{
    public static bool isDriving;

    public GameObject smoke;

    public static GameObject car;
    public Transform t;
    public Vector3 vR;

    SpriteRenderer sr;
    public CinemachineVirtualCamera cm;
    public CinemachineVirtualCamera cm2;
    
    public GameObject GetOut;

    Rigidbody2D RB;

    private float carXR;
    private float carYR;
    private float carZR;

    private float carX;
    private float carY;
    private float carZ;

    private Quaternion carRotation;

    public GameObject RootObjectOfHFactsTextBox;

    public static bool hasbeenincar;
    // Start is called before the first frame update
    void Start()
    {
        isDriving = false;
        RootObjectOfHFactsTextBox.SetActive(false);

        car = GameObject.FindGameObjectWithTag("car");
        sr = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();

        t = car.transform;
        vR = car.transform.eulerAngles;
        
        carXR = car.transform.rotation.x;
        carYR = car.transform.rotation.y;
        carZR = car.transform.rotation.z;

        carX = car.transform.position.x;
        carY = car.transform.position.y;
        carZ = car.transform.position.z;

        carRotation = car.transform.rotation;

        smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDriving == true)
        {
            hasbeenincar = true;

            RootObjectOfHFactsTextBox.SetActive(false);
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponent<Shoot>().enabled = false;
            this.GetComponent<CarController>().enabled = true;
            this.GetComponent<CarInputHandler>().enabled = true;
            RB.constraints = RigidbodyConstraints2D.None;

            sr.enabled = false;
            cm.m_Priority = 5;
            cm2.m_Priority = 10;

            RB.drag = 5f;
            RB.angularDrag = 20f;
            
            t = car.transform;
            vR = car.transform.eulerAngles;

        }
        if(isDriving == true && Input.GetKey(KeyCode.F))
        {
            if (isDriving == true)
            {
                carX = car.transform.position.x - .2F;
                carY = car.transform.position.y;
                carZ = car.transform.position.z;

                GetOut.transform.position = new Vector3(carX, carY, carZ);
                gameObject.transform.position = GetOut.transform.position;
                car.transform.parent = null;

                t = car.transform;
                vR = car.transform.eulerAngles;

                //carXR = transform.rotation.x;
                //carYR = transform.rotation.y;
                //carZR = transform.rotation.z * Mathf.Rad2Deg;

                //Debug.Log("=================ROTATION:    " + car.transform.rotation.z);
                //Debug.Log("=================EULER:    " + car.transform.localEulerAngles.z);
                //Debug.Log("================================CAR ZR:   " + carZR);

                isDriving = false;
            }
        }
        if(isDriving == false)
        {
            this.GetComponent<PlayerMovement>().enabled = true;
            this.GetComponent<Shoot>().enabled = true;
            this.GetComponent<CarController>().enabled = false;
            this.GetComponent<CarInputHandler>().enabled = false;

            sr.enabled = true;
            cm.m_Priority = 10;
            cm2.m_Priority = 5;

            RB.constraints = RigidbodyConstraints2D.FreezeRotation;
            RB.drag = 0f;
            RB.angularDrag = 0.05f;
            smoke.SetActive(false);
        }
        if(isDriving == true)
        {
            smoke.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "car" && isDriving == false)
        {
            RootObjectOfHFactsTextBox.SetActive(true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Car");

            if (collision.gameObject.tag == "car" && isDriving == false)
            {
                car.transform.eulerAngles = vR;
                transform.eulerAngles = vR;

                //carXR = transform.rotation.x;
                //carYR = transform.rotation.y;
                //carZR = transform.rotation.z;

                //car.transform.rotation = Quaternion.Euler(new Vector3(carXR, carYR, carZR));

                EnterCar();
            }   
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        RootObjectOfHFactsTextBox.SetActive(false);
    }

    private void EnterCar()
    {
        gameObject.transform.position = car.transform.position;
        gameObject.transform.rotation = Quaternion.Euler(carXR, carYR, carZR);
        car.transform.SetParent(gameObject.transform);
        car.transform.rotation = Quaternion.Euler(new Vector3(carXR, carYR, carZR));
        transform.eulerAngles = vR;

        //car.transform.rotation = carRotation;
        WaitForSeconds();
        //Invoke("PauseForABit",0.06f);
        smoke.SetActive(true);
        isDriving = true;
    }

    IEnumerable WaitForSeconds()
    {
        yield return new WaitForSeconds(.06F);
    }

    private void PauseForABit()
    {
        //isDriving = true;
    }
}
