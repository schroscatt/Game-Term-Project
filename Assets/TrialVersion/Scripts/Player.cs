using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public bool isSwing = false;
    public BoxCollider2D col;
    public CompositeCollider2D platform_col;
    public Transform swingTarget;
    private Vector3 ropeOffset;
    private Rigidbody2D body;
    
    public PlayerStateMachine StateMachine { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        StateMachine = GetComponent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //body.velocity = new Vector2(horizontal * 5f, body.velocity.y);
        
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump"))
        {
            //body.velocity = new Vector2(body.velocity.x, 9f);

        }
        
        if (Input.GetButton("Swing"))
        {
            isSwing = false;
            col.enabled = true;
        }

    }
    

    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 9f);
    }

    public void Move()
    {
        
    }

    public bool IsGrounded()
    {
        bool ret = Physics2D.IsTouching(col, platform_col);
        Debug.Log(ret);
        return ret;
    }
    public void AddGravity(float force)
    {
        body.AddForce(new Vector3(0, -force, 0));
    }
    //converts velocity vector to 2D, then gets its x, which is actually x and z velocities added together.
    public float GetVerticalVelocity()
    {
        return body.velocity.y;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("yandın");
        }
        if (collision.gameObject.CompareTag("rope") && StateMachine.CurState == StateMachine.JumpingState)
        {
            ropeOffset = transform.position - swingTarget.position;
            isSwing = true;
            col.enabled = false;
        }
    }

    public void Swing()
    {
        if (isSwing)
        {
            transform.position = swingTarget.position + ropeOffset;
        }
    }

    public void Walk()
    {
        Vector2 vel = body.velocity;
        vel.x = StateMachine.CurState.horizontalInput * StateMachine.speed;

        body.velocity = vel;
    }
}
