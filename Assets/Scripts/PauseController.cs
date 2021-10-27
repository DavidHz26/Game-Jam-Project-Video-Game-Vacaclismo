using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject MenuPausa;

    bool pausado;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !pausado)
        {
            pausado = true;
            MenuPausa.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P) && pausado)
        {
            pausado = false;
            MenuPausa.SetActive(false);
        }
    }

    public void Continue()
    {
        pausado = false;
        MenuPausa.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuP");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
