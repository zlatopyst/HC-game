using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public static event Action Button;
    public static event Action Button2;

    public void onResetClick()
    {
        Button.Invoke();
    }
    public void onNextClick()
    {
        Button2.Invoke();
    }
}
