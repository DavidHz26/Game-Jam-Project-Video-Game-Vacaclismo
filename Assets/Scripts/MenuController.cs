using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mCredits;
    bool inCredits;

    public Text Titulo1;
    public Text Titulo2;

    public Text Memoria;

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        if (!inCredits)
        {
            mCredits.SetActive(true);
            Titulo1.enabled = false;
            Titulo2.enabled = false;
            inCredits = true;
        }
        else if (inCredits)
        {
            mCredits.SetActive(false);
            Titulo1.enabled = true;
            Titulo2.enabled = true;
            inCredits = false;
        }
    }

    public void Regresar()
    {
        mCredits.SetActive(false);
        Titulo1.enabled = true;
        Titulo2.enabled = true;
        inCredits = false;
    }

}
