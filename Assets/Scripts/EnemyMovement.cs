using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float fltmoveSpeed = 1f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myRigidbody.velocity = new Vector2 (fltmoveSpeed, 0f);
    }

     void OnTriggerExit2D(Collider2D other) 
    {
        fltmoveSpeed = -fltmoveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2  (-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }

}
