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
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _ball.GetComponent<Rigidbody2D>().AddForce ( new Vector2(400, 400));
        }
    }
}