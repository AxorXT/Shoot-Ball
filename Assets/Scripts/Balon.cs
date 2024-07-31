using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Balon : MonoBehaviour
{
    private GameObject _player, _AI;
    public GameObject goals;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _AI = GameObject.FindGameObjectWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<Player>().canShoot = true;
        }
        if  (collision.gameObject.tag == "canShootAI")
        {
            _AI.GetComponent<AI>().canShootAI = true;
        }
        if(collision.gameObject.tag == "canHeadAI")
        {
            _AI.GetComponent<AI>().canHead= true;
        }
        if(collision.gameObject.tag == "GoalsDerecha")
        {
            if (GameController.instance.isScore == false && GameController.instance.EndMatch == false)
            {
                Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
                GameController.number_GoalsIzquierda++;
                GameController.instance.isScore = true;
                GameController.instance.ContinueMatch(true);
            }
        }
        if(collision.gameObject.tag == "GoalsIzquierda")
        {
            {
                if (GameController.instance.isScore == false && GameController.instance.EndMatch == false)
                {
                    Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
                    GameController.number_GoalsDerecha++;
                    GameController.instance.isScore = true;
                    GameController.instance.ContinueMatch(false);
                }
            }
        }

        if (collision.gameObject.tag == "BihindCol")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<Player>().canShoot = false;
        }
        if (collision.gameObject.tag == "canShootAI")
        {
            _AI.GetComponent<AI>().canShootAI = false;
        }

        if (collision.gameObject.tag == "canHeadAI")
        {
            _AI.GetComponent<AI>().canHead = false;
        }
    }
}
