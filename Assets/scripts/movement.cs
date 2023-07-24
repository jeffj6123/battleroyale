using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    private Animator Anim;
    public float m_Speed = 5f;
    public bool canMove = true;
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector

        float vertical = 0;
        float horizontal = 0;

        if(Input.GetKey("w")) {
            vertical += 1;
        }
        if(Input.GetKey("s")) {
            vertical -= 1;
        }
        if(Input.GetKey("a")) {
            horizontal -= 1;
        }
        if(Input.GetKey("d")) {
            horizontal += 1;
        }

        Vector3 m_Input = Vector3.Normalize(new Vector3(horizontal, 0, vertical));

        Anim.SetFloat("speed", Mathf.Abs(vertical + horizontal));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        if(canMove )
        {
            m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        }
        transform.forward = Vector3.Slerp(transform.forward, m_Input, Time.deltaTime * 10f);
    }
}