using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUIController : MonoBehaviour
{
    public GameObject creditsPopUp;
    public GameObject howToPlayPopUp;
    public GameObject settingsPopUp;
    public GameObject settingsPopUpEscMenu;
    public GameObject ESCPopUp;
    public static float musicValue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ESCPopUp.active == false)
        {
            ESCPopUp.active = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ESCPopUp.active == true)
        {
            ESCPopUp.active = false;
            Time.timeScale = 1;

        }
    }



    public void StartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




    public void CreditsButtonPressed()
    {
        if (creditsPopUp.active == false)
        {
            creditsPopUp.active = true;
        }
        else
        {
            creditsPopUp.active = false;
        }
    }




    public void HowtoPlayButtonPressed()
    {
        if (settingsPopUp.active == false)
        {
            settingsPopUp.active = true;
        }
        else
        {
            settingsPopUp.active = false;
        }
    }



    public void QuitButtonPressed()
    {
        Application.Quit();
    }




    public void SettingsButtonPressed()
    {
        if (settingsPopUp.active == false)
        {
            settingsPopUp.active = true;
        }
        else
        {
            settingsPopUp.active = false;
        }
    }


    public void BackToMenuPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseCreditsTab()
    {
        creditsPopUp.SetActive(false);
    }


    public void CloseHowToPlayTab()
    {
        howToPlayPopUp.SetActive(false);
    }

    public void OpenHowToPlayTab()
    {
        howToPlayPopUp.SetActive(true);
    }
}
