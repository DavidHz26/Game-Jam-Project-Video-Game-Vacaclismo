using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Leche;
    public int lecheInicial;
    public Text texto;

    void Start()
    {
        lecheInicial= 50;
        Leche = lecheInicial;
        
    }

    void Update()
    {
        texto.text = Leche.ToString();
    }

}
