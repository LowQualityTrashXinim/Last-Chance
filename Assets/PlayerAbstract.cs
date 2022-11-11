using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour
{
    public float Speed = 7;
    public float Jump = 500;
    public bool isJumping = false;
    public int JumpTimeBeforeDisable = 0;
    private float Move;
    List<string> InteractableObject = new List<string>() { "Ground", "Platform" };
    protected void Movement(Rigidbody2D rb)
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Speed * Move, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && JumpTimeBeforeDisable < 1)
        {
            Vector2 jump = new Vector2(rb.velocity.x, Jump);
            rb.AddForce(jump);
            JumpTimeBeforeDisable++;
        }
        if (isJumping)
        {
            JumpTimeBeforeDisable = 0;
        }
        else
        {
            if (Math.Round(rb.velocity.y,2) == 0)
            {
                JumpTimeBeforeDisable = 0;
            }
        }
    }

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
