using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float fltrunSpeed = 10f;
    [SerializeField] float fltjumpSpeed = 5f;
    [SerializeField] float fltclimbSpeed = 5f;
    Vector2 boolmoveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float fltgravityScaleAtStart;
    bool boolisAlive = true;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        fltgravityScaleAtStart = myRigidbody.gravityScale;
    }

    
    void Update()
    {
        if(!boolisAlive) {return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if(!boolisAlive) {return;}
        boolmoveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!boolisAlive) {return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;}
        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2 (0f, fltjumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (boolmoveInput.x * fltrunSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool boolplayerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", boolplayerHasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool boolplayerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (boolplayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }

        
    }

    void ClimbLadder()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        { 
            
            myRigidbody.gravityScale = fltgravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        
        Vector2 climbVelocity = new Vector2 (myRigidbody.velocity.x, boolmoveInput.y * fltclimbSpeed);
        
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        bool boolplayerHasverticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", boolplayerHasverticalSpeed);
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            boolisAlive = false;
        }
    }
}
