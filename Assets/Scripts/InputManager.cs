using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputManager : MonoBehaviour
{
    [SerializeField] private float yRBVelocity;
    private Vector3 velocityVector;

    private bool isGrounded;
    private int jumpCount;

    private Rigidbody rb;
    private float timer;

    private void Start()
    {
        velocityVector = Vector3.zero;
        velocityVector.y = yRBVelocity;

        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() 
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.y > Screen.height * 0.65f)
                return;


            //Проверка прыжка с земли
            if (jumpCount == 0 && !isGrounded)
                return;

            //Пользователь зажал
            if (jumpCount >= 2)
            {
                Holding(touch);
            }

            //Пользователь тапнул
            if (touch.phase == TouchPhase.Began && jumpCount < 2)
            {
                if (jumpCount == 1)
                {
                    //Двойной прыжок
                    if (rb.velocity.y < 1.0f)
                        Tap();
                    return;
                }

                //Первый прыжок
                Tap();
                return;
            }
        }
    }

    private void Tap()
    {
        if (isGrounded)
            isGrounded = false;
        rb.velocity = velocityVector;
        jumpCount++;
    }

    private void Holding(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            timer++;
        }

        if (timer > 1.0f && rb.velocity.y < 1.0f)
        {
            Physics.gravity = new Vector3(0.0f, -1.0f, 0.0f);
        }

        if (touch.phase == TouchPhase.Ended)
        {
            Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
            //timer = 0.0f;
            //jumpCount++;
            //return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
            isGrounded = true;
            jumpCount = 0;
            timer = 0.0f;
        }
    }
}
