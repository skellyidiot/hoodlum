using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarInputHandler : MonoBehaviour
{
    CarController carController;

    // Start is called before the first frame update
    void Start()
    {
        carController = GetComponent<CarController>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        carController.SetInputVector(inputVector);

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");
    }
}
