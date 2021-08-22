using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{

    [SerializeField] private float speedMove;
    [SerializeField] private float x;
    [SerializeField] private bool canMove = true;

    private float gravityForce;
    public Vector3 moveVector;

    private CharacterController ch_controller;
    private Animator ch_animator;
    public static float h; 
    public static float v;
    [SerializeField] private Animation anim;


    private Vector3 pos;
    private Quaternion rot;
    private float pushPower = 5.0f;

    private void Start()
    {
        anim = GetComponent<Animation>();
        x = speedMove;
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        pos = transform.position;
        rot = transform.rotation;
        Buttons.Button += Restart;
        Buttons.Button2 += Restart;
        Trap.Drop += Drop;
    }
    private void Update()
    {
        CharacterMove();
        Gravity();
        if (Collect.hold)
        {
            speedMove = x-1;
        }
        if (Collect.hold == false)
        {
            speedMove = x;
        }
    }
    private void LateUpdate()
    {

    }
    private void Drop()
    {
        canMove = false;
        ch_animator.SetTrigger("Fall");
    }

    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = h * speedMove;
        moveVector.z = v * speedMove;


       if (Collect.drop)
        {
            canMove = false;
            ch_animator.SetTrigger("Take");

        }
        if (Collect.drop == false & Trap.drop == false)
        {
            if ((moveVector.x != 0 || moveVector.z != 0) & Collect.hold == true & canMove == true)
            {
                ch_animator.SetBool("Walk", true);

            }
            else ch_animator.SetBool("Walk", false);


            if ((moveVector.x != 0 || moveVector.z != 0) & Collect.hold == false & canMove == true) ch_animator.SetBool("Move", true);
            else ch_animator.SetBool("Move", false);

            if (canMove == true)
            {
                if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
                {
                    Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
                    transform.rotation = Quaternion.LookRotation(direct);
                }
                moveVector.y = gravityForce;
                ch_controller.Move(moveVector * Time.deltaTime);
            }
        }
    }
    private void canMovee()
    {
        canMove = true;
        Collect.drop = false;
        ch_animator.ResetTrigger("Take");
    }
    private void falled()
    {
        canMove = true;
        Trap.drop = false;
        ch_animator.ResetTrigger("Fall");
    }

    private void Gravity()
    {
        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
        if(!hit.gameObject.CompareTag("Win"))
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.velocity = pushDir * pushPower;
        }
    }
    private void Restart()
    {
        transform.position = pos;
        transform.rotation = rot;
        speedMove = x;
        ch_animator.SetBool("Move", true);
    }
}
