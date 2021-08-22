using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private FloatingJoystick controller;
    private ManController manController;

    void Start()
    {
        manController = GetComponent<ManController>();
    }
    void Update()
    {
        ManController.v = -controller.input.y;
        ManController.h = -controller.input.x;
    }
}
