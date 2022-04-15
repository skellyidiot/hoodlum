using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMark : MonoBehaviour
{
    public TrailRenderer[] tiremarks;
    public bool TireMarksFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void checkDrift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) StartEmitter();
        else StopEmitter();
    }
    private void StartEmitter()
    {
        if (TireMarksFlag) return;
        foreach(TrailRenderer T in tiremarks)
        {
            T.emitting = true;
        }
        TireMarksFlag = true;
    }
    private void StopEmitter()
    {
        if (!TireMarksFlag) return;
        foreach(TrailRenderer T in tiremarks)
        {
            T.emitting = false;
        }

        TireMarksFlag = false;
    }
}
