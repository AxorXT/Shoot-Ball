using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float rangeDefense, speed;
    public Transform defense, checkGround;
    private GameObject _ball, _player;
    private Rigidbody2D rb_AI;
    public bool canShootAI, canHead, grounded;
    public LayerMask ground_layer;

    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Balon");
        rb_AI = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!GameController.instance.isScore && !GameController.instance.EndMatch)
        {
            Move();
            if (canShootAI)
            {
                if (ShouldUseAltShoot())
                {
                    ShootAlt();
                }
                else
                {
                    Shoot();
                }
            }
            if (canHead && grounded)
            {
                Jump();
            }
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
            if (Mathf.Abs(_ball.transform.position.x - transform.position.x) <= Mathf.Abs(_ball.transform.position.x - _player.transform.position.x) 
                && _ball.transform.position.y < 0.5f && _ball.transform.position.x > transform.position.x)
            {
                rb_AI.velocity = new Vector2(Time.deltaTime * speed, rb_AI.velocity.y);
            }
            else
            {
                if (_ball.transform.position.x > transform.position.x && _ball.transform.position.y < 0.5f)
                {
                    rb_AI.velocity = new Vector2(Time.deltaTime * speed, rb_AI.velocity.y);
                }
                else if (_ball.transform.position.y >= 0.5f && transform.position.x <= defense.position.x)
                {
                    rb_AI.velocity = new Vector2(0, rb_AI.velocity.y);
                }
                else
                {
                    rb_AI.velocity = new Vector2(-Time.deltaTime * speed, rb_AI.velocity.y);
                }
            }
        }
        else
        {
            if (transform.position.x < defense.position.x)
            {
                rb_AI.velocity = new Vector2(Time.deltaTime * speed, rb_AI.velocity.y);
            }
            else
            {
                rb_AI.velocity = new Vector2(0, rb_AI.velocity.y);
            }
        }
    }

    public void Shoot()
    {
        _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, -300));
    }

    public void ShootAlt()
    {
        _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 200));
    }

    private bool ShouldUseAltShoot()
    {
        return Vector2.Distance(transform.position, _ball.transform.position) < 1.0f;
    }

    public void Jump()
    {
        rb_AI.velocity = new Vector2(rb_AI.velocity.x, 15);
    }
}