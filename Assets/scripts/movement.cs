using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector

        int vertical = 0;
        int horizontal = 0;

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


        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        transform.forward = Vector3.Slerp(transform.forward, m_Input, Time.deltaTime * 10f);
    }
}