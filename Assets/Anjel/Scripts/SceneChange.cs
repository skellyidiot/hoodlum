using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string toScene;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1200, Screen.fullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneChange()
    {
        SceneManager.LoadScene(toScene);
    }

    public void exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
