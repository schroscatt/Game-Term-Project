using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    public Transform swingTarget;

    private bool isSwing = false;
    Rigidbody2D body;
    BoxCollider2D collider;

    
    public PlayerStateMachine StateMachine { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        StateMachine = new PlayerStateMachine();

        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * 5f, body.velocity.y);
        
        if (Input.GetButton("Jump"))
        {
            body.velocity = new Vector2(body.velocity.x, 9f);

        }
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
            transform.position = swingTarget.position;
        }
       
    }
    public void Jump()
    {
        body.AddForce(new Vector2(body.velocity.x, 9f));
    }

    public void Move()
    {
        
    }

    public void Swing()
    {

    }

    public bool IsGrounded()
    {
        return Physics.CheckBox(collider.bounds.center, new Vector2(collider.bounds.center.x, collider.bounds.min.y - 0.02f), Quaternion.identity, LayerMask.GetMask("Default"));

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

}
