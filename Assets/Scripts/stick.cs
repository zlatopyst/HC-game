using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public FloatingJoystick controller;
    private manController manController;
    // Start is called before the first frame update
    void Start()
    {
        manController = GetComponent<manController>();
    }

    // Update is called once per frame
    void Update()
    {
        manController.v = -controller.input.y;
        manController.h = -controller.input.x;
    }
}
