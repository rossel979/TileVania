using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float fltbulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float fltxSpeed;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        fltxSpeed = player.transform.localScale.x * fltbulletSpeed;
    }

    
    void Update()
    {
        myRigidbody.velocity = new Vector2 (fltxSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
