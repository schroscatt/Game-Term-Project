using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isSwing = false;
    public BoxCollider2D col;
    public CompositeCollider2D platform_col;
    public RopeController rope;
    private Vector3 ropeOffset;
    private Rigidbody2D body;
    
    public PlayerStateMachine StateMachine { get; private set; }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        StateMachine = GetComponent<PlayerStateMachine>();
    }

    void Update()
    {
        if (Input.GetButton("Swing"))
        {
            col.enabled = true;
            isSwing = false;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.IsTouching(col, platform_col); ;
    }

    public void AddGravity(float force)
    {
        body.AddForce(new Vector3(0, -force, 0));
    }

    public float GetVerticalVelocity()
    {
        return body.velocity.y;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("obstacle"))
        {
            SceneController.Instance.LoadFailLevel();
        }
        if (collision.gameObject.CompareTag("rope"))
        {
            rope = collision.gameObject.GetComponent<RopeController>();
            ropeOffset = transform.position - rope.swingTarget.position;
            isSwing = true;
            col.enabled = false;
        }
    }

    public void Swing()
    {
        if (isSwing)
        {
          transform.position = rope.swingTarget.position + ropeOffset;
        }
    }


    public void Walk()
    {
        Vector2 vel = body.velocity;
        vel.x=StateMachine.CurState.horizontalInput * StateMachine.speed;

        body.velocity = vel;
    }

    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 9f);
    }
}
