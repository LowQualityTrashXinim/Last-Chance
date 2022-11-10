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
    List<string> InteractableObject = new List<string>() { "Ground", "Platform" };
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            this.gameObject.SetActive(false);
        }
        foreach (string item in InteractableObject)
        {
            if (collision.gameObject.CompareTag(item))
            {
                isJumping = false;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < InteractableObject.Count; i++)
        {
            if (collision.gameObject.CompareTag(InteractableObject[i]))
            {
                isJumping = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (string item in InteractableObject)
        { 
            if (collision.gameObject.CompareTag(item))
            {
                isJumping = true;
            }
        }
    }
}
