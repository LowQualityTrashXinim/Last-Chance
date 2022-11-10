using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkspeed = 4;
    public bool Patrol;
    private bool mustTurn;
    public Transform check;
    private Rigidbody2D rb;
    public List<LayerMask> layer;
    public Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        Patrol = true;
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        if(Patrol)
        {
            for (int i = 0; i < layer.Count; i++)
            {
                mustTurn = !Physics2D.OverlapCircle(check.position, 0.1f, layer[i]);
                if (!mustTurn) break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Patrol)
        {
            Movement();
        }
    }
    void Movement()
    {
        for (int i = 0; i < layer.Count; i++)
        {
            if (mustTurn || collider.IsTouchingLayers(layer[i]))
            {
                Flip();
                break;
            }
        }
        rb.velocity = new Vector2(walkspeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        Patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed *= -1;
        Patrol = true;
    }
}
