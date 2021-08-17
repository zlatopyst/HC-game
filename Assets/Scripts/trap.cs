using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public static bool drop;
    public Transform parent;
    public Transform child;
    private float Pos;
    public Vector3 direction;
    public Transform point;
    private Vector3 pos;
    private Quaternion rot;
    // Start is called before the first frame update
    public static event Action Drop;
    void Start()
    {
        point = ItemsToFind.point;
        drop = false;
        Pos = transform.position.z;
        pos = transform.position;
        rot = transform.rotation;
        Buttons.Button += newStart;
       // Buttons.Button2 += newStart;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //drop = true;
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
}
