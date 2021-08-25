using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int countLevels;
    private GameObject[] Level;
    private GameObject[] LeveltoDestroy;

    public static event Action StopEvent;
    public static event Action StartEvent;
    private int count = 0;

    void Start()
    {
        Level = new GameObject[countLevels];
        LeveltoDestroy = new GameObject[countLevels];
        Buttons.Button2 += SwitchLevel;
        for (int i = 0; i < countLevels; i++)
        {
            Level[i] = Resources.Load<GameObject>("Level" + (i+1));
            Debug.Log(Level[i]);
        }
        LeveltoDestroy[count] = Instantiate(Level[count]);
    }

    private void SwitchLevel()
    {
        Debug.Log(count);     
            StopEvent.Invoke();
            Destroy(LeveltoDestroy[count]);
        if ((count + 1) >= countLevels)
        {
            count = -1;
        }
        LeveltoDestroy[count + 1] = Instantiate(Level[count + 1]);
            StartEvent.Invoke();
            count++;
    }
}
