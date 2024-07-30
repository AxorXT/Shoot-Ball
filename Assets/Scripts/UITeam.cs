using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeam : MonoBehaviour
{
    public static UITeam instance;
    public Sprite[] BanderaEquipo;
    public String[] NombreTeam;

    public Sprite[] head, body, shoe;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
