using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void startFunction()
    {

        SceneManager.LoadScene("LoadingScreen");
    }


    public void retryFunction()
    {

        SceneManager.LoadScene("level 1");
    }

    public void creditFunction()
    {

        SceneManager.LoadScene("credit");
    }

    public void cerezo()
    {

        SceneManager.LoadScene("cerezo");
    }

    public void Lenard()
    {

        SceneManager.LoadScene("Lenard");
    }
    public void dhan()
    {

        SceneManager.LoadScene("dhan");
    }

    public void baks()
    {

        SceneManager.LoadScene("baks");
    }

    public void cj()
    {

        SceneManager.LoadScene("cj");
    }



    public void Diaz1()
    {

        SceneManager.LoadScene("Diaz 1");
    }


    public void menuFunction()
    {

        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
