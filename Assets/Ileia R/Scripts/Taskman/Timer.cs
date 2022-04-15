using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        string textTime = string.Format("{0}", Mathf.RoundToInt(time));

        //if(time <= 0 && TaskmanTXTbox.doneTask2 == false)
        //{
        //    stopTimer = true;
        //    sliderObject.SetActive(false);
        //}
        if(TaskmanTXTbox.doingTask3 == true)
        {
            //time -= Time.deltaTime;
            time = AllTasks.timeLeft;
            sliderObject.SetActive(true);
            timerText.text = textTime;
            timerSlider.value = Mathf.RoundToInt(time);
        }
        if (TaskmanTXTbox.doneTask3 == true)
        {
            stopTimer = true;
            time = 60;
            sliderObject.SetActive(false);
        }
        if(time == 0)
        {
            timerText.text = textTime;
            timerSlider.value = AllTasks.timeLeft;
        }
    }
}
