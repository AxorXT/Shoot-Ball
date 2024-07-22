using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Image BanderaPlayer;
    public Text NamePlayer;
    public Image BanderaAI;
    public Text NameAI;
    
    // Start is called before the first frame update
    void Start()
    {
        
        /*valueAI = PlayerPrefs.GetInt("valueAI", 1);*/
    }

    // Update is called once per frame
    void Update()
    {
        //UI del Player 1
        BanderaPlayer.sprite = UITeam.instance.BanderaEquipo[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        NamePlayer.text = UITeam.instance.NombreTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        
        //UI del Player 2 o AI la computadora
        BanderaAI.sprite = UITeam.instance.BanderaEquipo[PlayerPrefs.GetInt("valueAI", 1) - 1];
        NameAI.text = UITeam.instance.NombreTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
    }

    public void ButtonBack()
    {
        Application.LoadLevel("Menu");
    }

    public void ButtonIzquierdaPlayer1()
    {
        if (PlayerPrefs.GetInt("valuePlayer", 1) <= 1)
        {
            PlayerPrefs.SetInt("valuePlayer", 8);
        }
        else
        {
            int valuePlayer = PlayerPrefs.GetInt("valuePlayer", 1);
            valuePlayer--;
            PlayerPrefs.SetInt("valuePlayer", valuePlayer);
        }
    }

    public void ButtonDerechaPlayer1()
    {
        if (PlayerPrefs.GetInt("valuePlayer", 1) >= 8)
        {
            PlayerPrefs.SetInt("valuePlayer", 1);
        }
        else
        {
            int valuePlayer = PlayerPrefs.GetInt("valuePlayer", 1);
            valuePlayer++;
            PlayerPrefs.SetInt("valuePlayer", valuePlayer);
        }
    }

    public void ButtonIzquierdaAI()
    {
        if (PlayerPrefs.GetInt("valueAI", 1) <= 1)
        {
            PlayerPrefs.SetInt("valueAI", 8);
        }
        else
        {
            int valueAI = PlayerPrefs.GetInt("valueAI", 1);
            valueAI--;
            PlayerPrefs.SetInt("valueAI", valueAI);
        }
    }

    public void ButtonDerechaAI()
    {
        if (PlayerPrefs.GetInt("valueAI", 1) >= 8)
        {
            PlayerPrefs.SetInt("valueAI", 1);
        }
        else
        {
            int valueAI = PlayerPrefs.GetInt("valueAI", 1);
            valueAI++;
            PlayerPrefs.SetInt("valueAI", valueAI);
        }
    }
}
