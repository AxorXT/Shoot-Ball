using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public float horialAxis, speed;
    private Rigidbody2D rb_player;
    public bool canShoot, grounded;
    private GameObject _ball;
    public Transform checkGround;
    public LayerMask ground_layer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("Balon");
    }

    // Update is called once per frame
    void Update()
    {
        horialAxis = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb_player.velocity = new Vector2(Time.deltaTime * speed * horialAxis, rb_player.velocity.y);
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_layer);
    }

    public void Move(int value)
    {
        horialAxis = value;
    }

    public void StopMove()
    {
        horialAxis = 0;
    }

    public void Shoot()
    {
        if (canShoot == true)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 500));
        }
    }
    
    public void Jump()
    {
        if (grounded == true)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);
        }
    }
}
