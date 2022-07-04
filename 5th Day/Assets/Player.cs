using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    bool canJump;
    public Animator animator;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        jump = 5;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            animator.SetBool("Jump", false);
        }
        else if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = rb.velocity;

        if (Input.GetAxis("Horizontal") > 0)
            sprite.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sprite.flipX = true;

        if(canJump && Input.GetKey(KeyCode.Space))
        {
            temp.y = jump;
            canJump = false;
            animator.SetBool("Jump", true);
          
        }
         
        temp.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = temp;
    }

    
}
