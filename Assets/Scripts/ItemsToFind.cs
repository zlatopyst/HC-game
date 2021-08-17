using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToFind : MonoBehaviour
{
    public Transform hand1;
    public Transform point1;
    public GameObject Winwin1;
    public GameObject Lose1;
    public static Transform hand;
    public static Transform point;
    public static GameObject Winwin;
    public static GameObject Lose;
    //public static Transform target;

    // Start is called before the first frame update
    void Start()
    {
        hand = hand1;
        point = point1;
        Winwin = Winwin1;
        Lose = Lose1;
    }

    // Update is called once per frame
    void Update()
    {
        //target = GameObject.FindWithTag("Win").GetComponent<Transform>();
    }
}
