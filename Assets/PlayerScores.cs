using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public TMP_Text scoreText;
    private System.Random random = new System.Random();

    public TMP_InputField nameText;

    public static int playerScore;
    public static string playerName;


    void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
    }

    public void OnSubmit()
    {
        Debug.Log("calsti");
        playerName = nameText.text;
        PostToDatabase();
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Post("https://farwees-u29-default-rtdb.firebaseio.com/.json", user);
    }

}
