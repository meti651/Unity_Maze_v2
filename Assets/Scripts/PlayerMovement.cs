using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool HasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool HasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool IsWalking = HasHorizontalInput || HasVerticalInput;

        Vector3 movement = Vector3.zero;
        if (HasHorizontalInput)
        {
            if (vertical < 0)
            {
                movement += -transform.right;
                movement *= horizontal;
            }
            else
            {
                movement += transform.right;
                movement *= horizontal;
            }

        }
        if (HasVerticalInput)
        {
            movement += transform.forward;
            movement *= vertical;
        }


        m_Movement.Set(movement.x, movement.y, movement.z);

        m_Animator.SetBool("IsWalking", IsWalking);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude * speed);
    }
}
