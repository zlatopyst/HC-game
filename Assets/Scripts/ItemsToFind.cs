using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToFind : MonoBehaviour
{
    [SerializeField] private Transform hand1;
    [SerializeField] private Transform point1;
    [SerializeField] private GameObject Winwin1;
    [SerializeField] private GameObject Lose1;
    public static Transform hand;
    public static Transform point;
    public static GameObject Winwin;
    public static GameObject Lose;
    //public static Transform target;


    void Start()
    {
        hand = hand1;
        point = point1;
        Winwin = Winwin1;
        Lose = Lose1;
    }


    void Update()
    {
        //target = GameObject.FindWithTag("Win").GetComponent<Transform>();
    }
}
