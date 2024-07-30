using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text txt_GoalsDerecha, txt_GoalsIzquierda, txt_timeMatch;
    public int number_GoalsDerecha, number_GoalsIzquierda;
    public bool isScore, EndMatch;
    public float timeMatch;
    private GameObject _ball, _AI, _Player;

    public Image BanderaIzquierda, BanderaDerecha;
    public Text nombreIzquierdo, nombreDerecho;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeMatch = 90;
        _ball = GameObject.FindGameObjectWithTag("Balon");
        _AI = GameObject.FindGameObjectWithTag("AI");
        _Player = GameObject.FindGameObjectWithTag("Player");
        
        
        StartCoroutine(BeginMatch());
    }

    // Update is called once per frame
    void Update()
    {
        txt_GoalsIzquierda.text = number_GoalsIzquierda.ToString();
        txt_GoalsDerecha.text = number_GoalsDerecha.ToString();
        txt_timeMatch.text = timeMatch.ToString();
    }

    IEnumerator BeginMatch()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (timeMatch > 0)
            {
                timeMatch--;
            }
            else
            {
                EndMatch = true;
                break;
            }
        }
        
    }

    public void ContinueMatch(bool winPlayer)
    {
        StartCoroutine(WaitContinueMatch(winPlayer));
    }

    IEnumerator WaitContinueMatch(bool winPlayer)
    {
        yield return new WaitForSeconds(2f);
        isScore = false;
        if (EndMatch == false)
        {
            _ball.transform.position = new Vector3(0, 0, 0);
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _AI.transform.position = new Vector3(5, 0, 0);
            _Player.transform.position = new Vector3(-5, 0, 0);
            if (winPlayer == true)
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
            }
            else
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 200));
            }
        }
    }
    
}
