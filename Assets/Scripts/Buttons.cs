using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public static int x = 0;

    public static event Action Button;
    public static event Action Button2;
    private int but;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
       //if(x==1) x = 0;
    }
    public void onResetClick()
    {
        Button.Invoke();
    }
    public void onNextClick()
    {
        Button2.Invoke();
    }
}
