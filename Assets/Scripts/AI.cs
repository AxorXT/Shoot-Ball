using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float rangeDefense, speed;
    public Transform defense, checkGround;
    private GameObject _ball;
    private Rigidbody2D rb_AI;
    public bool canShootAI, canHead, grounded;
    public LayerMask ground_layer;

    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Balon");
        rb_AI = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (canShootAI == true)
        {
            Shoot();
        }
        if (canHead == true && grounded == true)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_layer);
    }

    public void Move()
    
        
        {
            if (Mathf.Abs(_ball.transform.position.x - transform.position.x) < rangeDefense)
            {
                if (_ball.transform.position.x > transform.position.x && _ball.transform.position.y < -0.5f)
                {
                    rb_AI.velocity = new Vector2(speed * Time.deltaTime, rb_AI.velocity.y);
                }

                else if (_ball.transform.position.y == -0.5f && transform.position.x <= defense.position.x)
                {
                    rb_AI.velocity = new Vector2(0, rb_AI.velocity.y);

            }

                else
                {
                    rb_AI.velocity = new Vector2(-speed * Time.deltaTime, rb_AI.velocity.y);
                }
            }
            else
            {
                if (transform.position.x > defense.position.x)
                {
                    rb_AI.velocity = new Vector2(-Time.deltaTime * speed, rb_AI.velocity.y);
                }
                else
                {
                    rb_AI.velocity = new Vector2(0, rb_AI.velocity.y);
                }
            }
        }
    public void Shoot()
    {
        _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 300));
    }

    public void Jump()
    {
        rb_AI.velocity = new Vector2(rb_AI.velocity.x, 15);
    }
}
