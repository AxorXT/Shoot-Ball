using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fin : MonoBehaviour
{
    public Image flagLeft, flagRight;
    public Text result, goals;

    // Start is called before the first frame update
    void Start()
    {
        flagLeft.sprite = UITeam.instance.BanderaEquipo[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        flagRight.sprite = UITeam.instance.BanderaEquipo[PlayerPrefs.GetInt("valueAI", 1) - 1];

        goals.text = GameController.number_GoalsIzquierda + " : " + GameController.number_GoalsDerecha;

        if(GameController.number_GoalsIzquierda > GameController.number_GoalsDerecha)
        {
            result.text = "Has perdido";
        }
        else if (GameController.number_GoalsIzquierda == GameController.number_GoalsDerecha)
        {
            result.text = "Empate";
        }

        else
        {
            result.text = "Has Ganado";
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonHome ()
    {
        Application.LoadLevel("Menu");
    }

    public void ButtonRematch()
    {
        Application.LoadLevel("Juego");
    }

    public void ButtonExibicon()
    {
        Application.LoadLevel("Seleccion");
    }
}
