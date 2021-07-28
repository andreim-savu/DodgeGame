using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6.0f;

    Vector3 movementVector = Vector3.zero;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movementVector.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVector.z = -1;
        }
        else
        {
            movementVector.z = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -1;
        }
        else
        {
            movementVector.x = 0;
        }

        movementVector = movementVector.normalized;

        transform.Translate(movementVector * movementSpeed * Time.fixedDeltaTime);
    }
}
