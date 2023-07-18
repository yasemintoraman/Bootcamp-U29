using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStoryAnim : MonoBehaviour
{
    public GameObject dialogCanvas;
    public GameObject endSceneAnim;
    private bool isEndGame;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StoryStartAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame == false && GorevKontrol.yemisCount >= 5)
        {
            StartCoroutine(StoryEndAnim());
            isEndGame = true;
        }
    }


    IEnumerator StoryStartAnim()
    {
        dialogCanvas.SetActive(false);
        yield return new WaitForSeconds(10f);
        dialogCanvas.SetActive(true);

    }

    IEnumerator StoryEndAnim()
    {
        dialogCanvas.SetActive(false);
        endSceneAnim.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    //IEnumerator StoryStartAnimText()
    //{


    //}
}
