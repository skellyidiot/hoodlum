using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject[] Slides;
    public int CurrSlide = 0;
    public int Length = 0;
    // Start is called before the first frame update
    void Start()
    {
        Length = Slides.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            Slides[CurrSlide].SetActive(false);
            if (CurrSlide >= Length)
            {
                CurrSlide = 0;
            }
            else
            {
                
                CurrSlide += 1;
                
            }
            Slides[CurrSlide].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (CurrSlide > 0)
            {
                Slides[CurrSlide].SetActive(false); CurrSlide -= 1; Slides[CurrSlide].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
