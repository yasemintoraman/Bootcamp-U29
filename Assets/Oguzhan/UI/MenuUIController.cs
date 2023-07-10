using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public GameObject creditsPopUp;
    public GameObject settingsPopUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
