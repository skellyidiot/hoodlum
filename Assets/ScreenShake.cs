using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{

    public static ScreenShake Instance { get; private set; }
    CinemachineVirtualCamera cmvc;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cmvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intence,float time)
    {
        
        CinemachineBasicMultiChannelPerlin cmbmcp = cmvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmbmcp.m_AmplitudeGain = intence;
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cmbmcp = cmvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cmbmcp.m_AmplitudeGain = 0f;
            }
        }
    }
}
