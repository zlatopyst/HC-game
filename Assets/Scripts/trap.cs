using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public static bool drop;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform child;
    private float Pos;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Transform point;
    private Vector3 pos;
    private Quaternion rot;

    public static event Action Drop;
    void Start()
    {
        point = ItemsToFind.point;
        drop = false;
        Pos = transform.position.z;
        pos = transform.position;
        rot = transform.rotation;
        Buttons.Button += newStart;
        NextLevel.StopEvent += StopEvent;
        NextLevel.StartEvent += StartEvent;
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Drop.Invoke();
            GetComponent<BoxCollider>().enabled = false;
            Ray ray = new Ray(point.transform.position, point.transform.forward);
                GetComponent<Rigidbody>().AddForce(ray.direction * 300f);

        }
    }
    private void newStart()
    {
        GetComponent<BoxCollider>().enabled = true;
        transform.position = pos;
        transform.rotation = rot;
    }
    private void StopEvent()
    {
        Buttons.Button -= newStart;
    }
    private void StartEvent()
    {
       // Buttons.Button += newStart;
    }
}
