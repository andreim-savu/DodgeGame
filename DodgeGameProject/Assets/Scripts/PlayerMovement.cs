using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6.0f;

    bool disabled;

    Vector3 movementVector = Vector3.zero;

    IEnumerator pushRoutine;

    void FixedUpdate()
    {
        if (disabled) { return; }

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

    public void StartPush(Vector3 direction)
    {
        pushRoutine = GetPushed(direction);
        StartCoroutine(pushRoutine);
    }

    IEnumerator GetPushed(Vector3 direction)
    {
        disabled = true;
        float duration = 0.15f;
        while (duration > 0)
        {
            transform.Translate(direction * 25.0f * Time.deltaTime);
            duration -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        disabled = false;
    }
}
