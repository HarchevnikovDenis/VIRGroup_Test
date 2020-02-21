using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputManager : MonoBehaviour
{
    [SerializeField] private float yVelocity;
    private Vector3 velocityVector;

    private Rigidbody rigidbody;

    private int jumpCount;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        velocityVector = new Vector3(0.0f, yVelocity, 0.0f);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            Jump();
            return;
        }

        if(jumpCount == 2 && Input.GetMouseButtonDown(0))
        {
            Physics.gravity = new Vector3(0.0f, -0.75f, 0.0f);
            rigidbody.velocity = new Vector3(0.0f, -0.5f, 0.0f);
        }

        if(jumpCount == 2 && Input.GetMouseButtonUp(0) && Physics.gravity.y != -9.81f)
        {
            Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
        }
    }

    private void Jump()
    {
        rigidbody.velocity = velocityVector;
        jumpCount++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;

            if(Physics.gravity.y != -9.81f)
            {
                Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
            }
        }
    }
}
