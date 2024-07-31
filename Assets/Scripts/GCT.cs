using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCT : MonoBehaviour
{
    public static GCT instance;
    public Text txt_GoalsDerecha, txt_GoalsIzquierda, txt_timeMatch;
    public static int number_GoalsDerecha, number_GoalsIzquierda;
    public bool isScore, EndMatch;
    public float timeMatch;
    private GameObject _ball, _AI, _Player;
    public GameObject panelPause;

    public Image BanderaIzquierda, BanderaDerecha;
    public Text nombreIzquierdo, nombreDerecho;

    public SpriteRenderer headPlayer, bodyPlayer, shoePlayer, headAI, bodyAI, shoeAI;

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
        number_GoalsDerecha = 0;
        number_GoalsIzquierda = 0;
        timeMatch = 90;
        _ball = GameObject.FindGameObjectWithTag("Balon");
        _AI = GameObject.FindGameObjectWithTag("AI");
        _Player = GameObject.FindGameObjectWithTag("Player");

        BanderaIzquierda.sprite = UITeam.instance.BanderaEquipo[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        nombreIzquierdo.text = UITeam.instance.NombreTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        BanderaDerecha.sprite = UITeam.instance.BanderaEquipo[PlayerPrefs.GetInt("valueAI", 1) - 1];
        nombreDerecho.text = UITeam.instance.NombreTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];

        headAI.sprite = UITeam.instance.head[PlayerPrefs.GetInt("valueAI", 1) - 1];
        bodyAI.sprite = UITeam.instance.body[PlayerPrefs.GetInt("valueAI", 1) - 1];
        shoeAI.sprite = UITeam.instance.shoe[PlayerPrefs.GetInt("valueAI", 1) - 1];

        headPlayer.sprite = UITeam.instance.head[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        bodyPlayer.sprite = UITeam.instance.body[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        shoePlayer.sprite = UITeam.instance.shoe[PlayerPrefs.GetInt("valuePlayer", 1) - 1];

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
                StartCoroutine(WaitFin());
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

    public void ButtonPause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonResume()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void ButtonLose()
    {
        number_GoalsIzquierda = 3;
        number_GoalsDerecha = 0;
        timeMatch = 0;
        panelPause.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(WaitFin());

    }

    IEnumerator WaitFin()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Fin");
    }


}
