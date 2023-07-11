using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUIController : MonoBehaviour
{
    public GameObject creditsPopUp;
    public GameObject settingsPopUp;
    public GameObject settingsPopUpEscMenu;
    public GameObject ESCPopUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ESCPopUp.active == false)
        {
            ESCPopUp.active = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ESCPopUp.active == true)
        {
            ESCPopUp.active = false;
        }

    }



    public void StartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsButtonPressed()
    {

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

    public void SettingsButtonPressedESCMenu()
    {
        if (settingsPopUpEscMenu.active == false)
        {
            settingsPopUpEscMenu.active = true;
        }
        else
        {
            settingsPopUpEscMenu.active = false;
        }
    }


    public void BackToMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
