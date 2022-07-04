using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int direction;
    public Rigidbody2D rb;
    public GameObject leftTrigger;
    public GameObject rightTrigger;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        direction = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * speed * direction;
        
        if(direction > 0)
        {
           Collider2D check = Physics2D.OverlapBox(rightTrigger.transform.position,Vector2.one * 0.5f, 0f);

            if (check == null || check.tag != "Ground")
                direction = -direction;

        }

        if (direction < 0)
        {
            Collider2D check = Physics2D.OverlapBox(leftTrigger.transform.position, Vector2.one * 0.5f, 0f);

            if (check == null || check.tag != "Ground")
                direction = -direction;

        }

    }
}
