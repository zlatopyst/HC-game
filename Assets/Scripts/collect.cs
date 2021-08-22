using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    public static bool hold = false;
    public static bool drop = false;
    public static bool fall = false;

    [SerializeField] private bool Localhold = false;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform loc;
    [SerializeField] private float Speed = 15f;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject ZoneItem;

    private Vector3 pos;
    private Quaternion rot;
    private Vector3 scale;


    void Start()
    {
        hand = ItemsToFind.hand;
        point = ItemsToFind.point;
        pos = transform.position;
        rot = transform.rotation;
        scale = transform.localScale;
        Buttons.Button += newStart;
        Trap.Drop += Drop;
    }


    void IsTrigger()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            hold = true;
            Localhold = true;
            OnHand();
            drop = true;
        }
        if (other.gameObject.tag == "Item")
        {
            transform.parent = loc.transform;
            transform.position = pos + new Vector3(0f,-5f,0f);
            transform.rotation = rot;
            ZoneItem.SetActive(true);
            hold = false;
            Localhold = false;
            drop = false;
        }

    }
    private void OnHand()
    {
        transform.position = hand.position;
        transform.parent = hand.transform;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().isTrigger = false;
    }
    private void Drop()
    {
        RaycastHit hit;
        Ray ray = new Ray(point.transform.position, point.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
        if (Physics.Raycast(point.transform.position, point.transform.forward, out hit))
        {
            if (Localhold == true)
            {
                Vector3 dir = hit.point;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<MeshCollider>().enabled = true;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = loc.transform;
                GetComponent<Rigidbody>().AddForce(dir * Speed);
                Invoke(nameof(IsTrigger), 3.5f);
                hold = false;
                Localhold = false;
            }
        }
    }
    private void newStart()
    {
        if (this.gameObject != null)
        {
            hold = false;
            Localhold = false;
            drop = true;
            transform.parent = loc.transform;
            transform.rotation = rot;
            transform.position = pos;
            GetComponent<MeshCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            Invoke(nameof(IsTrigger), 2f);
            ZoneItem.SetActive(false);
        }
    }

}
