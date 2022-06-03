using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    Rigidbody2D body;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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

        }
       
    }
}
