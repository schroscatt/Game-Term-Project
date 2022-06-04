using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    
    public Transform swingTarget;

    private bool isSwing = false;
    Rigidbody2D body;
    BoxCollider2D col;
    private Vector3 ropeOffset;
    public CompositeCollider2D platform_col;

    
    public PlayerStateMachine StateMachine { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //body.velocity = new Vector2(horizontal * 5f, body.velocity.y);
        
        if (Input.GetButton("Jump"))
        {
            //body.velocity = new Vector2(body.velocity.x, 9f);

        }

    }

    private void LateUpdate()
    {
        if (Input.GetButtonDown("Swing"))
        {
            isSwing = !isSwing;
            if (isSwing && (transform.position - swingTarget.position).magnitude >= 2f)
            {
                isSwing = false;
            }
        }

        if (isSwing)
        {
            transform.position = swingTarget.position + ropeOffset;
        }
    }

    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 9f);
    }

    public void Move()
    {
        
    }

    public void Swing()
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

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("yandın");
        }
        if (col.gameObject.CompareTag("rope"))
        {
            ropeOffset = transform.position - swingTarget.position;
            isSwing = true;
        }
    }
}
