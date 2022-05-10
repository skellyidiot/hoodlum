using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject sliderObject;
    public Slider timerSlider;
    public Text timerText;
    public float time;

    private bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        //stopTimer = false;
        time = AllTasks.timeLeft;

        timerSlider.maxValue = time;
        timerSlider.value = time;

        sliderObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //time = AllTasks.timeLeft;
        string textTime = string.Format("{0}", Mathf.RoundToInt(time));

        if (time <= 0 && TaskmanTXTbox.doingTask3)
        {
            time = 60;
            TaskmanTXTbox.doingTask3 = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            sliderObject.SetActive(false);
        }
        if (TaskmanTXTbox.doingTask3 == true && TaskmanTXTbox.doingTask1 == false && TaskmanTXTbox.doingTask2 == false)
        {
            time -= Time.deltaTime;
            //time = AllTasks.timeLeft;
            sliderObject.SetActive(true);
            timerText.text = textTime;
            timerSlider.value = Mathf.RoundToInt(time);
            Debug.Log(AllTasks.timeLeft);
        }
        if (TaskmanTXTbox.doneTask3 == true)
        {
            //stopTimer = true;
            time = 60;
            sliderObject.SetActive(false);
        }
        //if(time <= 58)
        //{
        //    SceneManager.LoadScene("mainLevl");
        //}
    }
}
