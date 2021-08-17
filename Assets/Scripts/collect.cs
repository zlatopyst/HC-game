using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{

    public static bool hold = false;
    public bool Localhold = false;
    //public static bool anim = false;
    public static bool drop = false;
    public Transform hand; 
    public Transform loc;
    public float Speed = 15f;
    public Transform point;
    public GameObject ZoneItem;
    public static bool fall = false;

    //private Animator drop_animator;
    private Vector3 pos;
    private Quaternion rot;
    private Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        hand = ItemsToFind.hand;
        point = ItemsToFind.point;
        //point = GameObject.FindWithTag("Point").GetComponent<Transform>();
        //drop_animator = this.gameObject.GetComponent<Animator>();
        pos = transform.position;
        rot = transform.rotation;
        scale = transform.localScale;
        //parent = this.gameObject.transform.GetChild(0);
        Buttons.Button += newStart;
        //Buttons.Button2 += newStart;
        trap.Drop += Drop;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void isTrigger()
    {
        //drop_animator.SetBool("Drop", false);
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (trap.drop)
        //{
         //   hold = false;
         //   fall = true;
         //   Drop();
          //  Invoke("isTrigger", 5f);
        //}
        if (other.gameObject.tag == "Player")
        {
            hold = true;
            Localhold = true;
            OnHand();
            drop = true;
            //drop_animator.SetBool("Take", false);
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
   /* private void OnCollisionEnter(Collision collision)
    {
        hold = true;
       OnHand();
    }*/
    private void OnHand()
    {
        //transform.localScale = transform.localScale - new Vector3(0.5f, 0.5f, 0.5f);
        //drop_animator.SetTrigger("Take");
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
                //transform.localScale = scale;
                GetComponent<Rigidbody>().AddForce(dir * Speed);
                //drop_animator.SetTrigger("Drop");
                Invoke("isTrigger", 3.5f);
                //transform.localScale = scale;
                //transform.position = parent.position;
                hold = false;
                Localhold = false;
            }
        }
    }
    private void newStart()
    {
        transform.parent = loc.transform;
        transform.rotation = rot;
        transform.position = pos;
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        Invoke("isTrigger", 2f);
        ZoneItem.SetActive(false);
        //transform.localScale = scale;
        hold = false;
        Localhold = false;
        drop = true;
    }

}
