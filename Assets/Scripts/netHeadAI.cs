using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netHeadAI : MonoBehaviour
{
    private GameObject _ball;

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Balon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Balon")
        {
            if (ShouldUseAltHead())
            {
                HeadAlt();
            }
            else
            {
                Head();
            }
        }
    }

    public void Head()
    {
        _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 100));
    }

    public void HeadAlt()
    {
        _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 200));
    }

    private bool ShouldUseAltHead()
    {
        // Example condition: use alternate head if the ball is closer to the net
        return Vector2.Distance(transform.position, _ball.transform.position) < 2.0f;
    }
}