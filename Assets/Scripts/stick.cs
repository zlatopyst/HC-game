using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class stick : MonoBehaviour
{
    public FloatingJoystick controller;
    private ThirdPersonUserControl thirdPersonUserControl;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        thirdPersonUserControl.h = controller.input.x;
        thirdPersonUserControl.v = controller.input.y;
    }
}
