using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : PlayerAbstract
{
    //For private and misc change
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(rb);
        if (rb.velocity.y < -20)
        {
            rb.velocity = new Vector2(rb.velocity.x,-20);
        }
        if (rb.velocity.y > 12)
        {
            rb.velocity = new Vector2(rb.velocity.x, 12);
        }
    }
}
