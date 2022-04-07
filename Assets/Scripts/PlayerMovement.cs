using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float fltrunSpeed = 10f;
    Vector2 boolmoveInput;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        boolmoveInput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (boolmoveInput.x * fltrunSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }
}
