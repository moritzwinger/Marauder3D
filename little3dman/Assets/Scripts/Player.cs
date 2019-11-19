using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    public float speed = 6.0f;
    public float turnSpeed = 60.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 jumpDirection = Vector3.zero;
    public float gravity = 20.0f;



    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            anim.SetInteger("AnimParam", 1);
        } 
        else if (Input.GetKey("e")) 
        {
          //  anim.SetInteger("AnimParam", 2);
        } 
        else
        {
            anim.SetInteger("AnimParam", 0);
        }
        if (controller.isGrounded)
        {
            moveDirection = -transform.right * Input.GetAxis("Vertical") * speed;
            if (Input.GetKey("e"))
            {
                jumpDirection = new Vector3(0, 500, 0);
                //controller.Move(jumpDirection * Time.deltaTime);
               // controller.transform.position = Vector3.Slerp(controller.transform.position, controller.transform.position + jumpDirection * Time.deltaTime, 1);
            }
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

    }
}

