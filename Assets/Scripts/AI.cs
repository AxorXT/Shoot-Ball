using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float rangeDefense, speed;
    public Transform defense;
    private GameObject _balon;
    private Rigidbody2D rb_AI;
    public bool canShootAI, canHead;

    void Start()
    {
        _balon = GameObject.FindGameObjectWithTag("Balon");
        rb_AI = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (canShootAI == true)
        {
            Shoot();
        }
        if (canHead == true)
        {
            Jump();
        }
    }

    public void Move()
    
        
        {
            if (Mathf.Abs(_balon.transform.position.x - transform.position.x) < rangeDefense)
            {
                if (_balon.transform.position.x > transform.position.x)
                {
                    rb_AI.velocity = new Vector2(speed * Time.deltaTime, rb_AI.velocity.y);
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
        _balon.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 500));
    }

    public void Jump()
    {
        rb_AI.velocity = new Vector2(rb_AI.velocity.x, 15);
    }
}
