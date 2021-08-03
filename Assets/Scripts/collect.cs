using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public GameObject myPlayer;
    private float distance;
    public float maxdistance = 100f;
    public bool hold;
    public Transform hand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Item()
    {
        distance = Vector3.Distance(myPlayer.GetComponent<Transform>().position, transform.position);
        if (distance < maxdistance)
        {
            hold = false;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnHand();
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        hold = true;
       OnHand();
    }*/
    private void OnHand()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        transform.position = hand.position;
        transform.parent = hand.transform;
    }
}
