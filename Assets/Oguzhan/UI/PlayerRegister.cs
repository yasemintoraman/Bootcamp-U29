using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRegister : MonoBehaviour
{
    public TMP_Text idText;
    private System.Random random = new System.Random();

    public TMP_InputField nameText;

    public static int playerID;
    public static string playerUserName;



    void Start()
    {
        playerID = random.Next(0, 1001);
        idText.text = "Player ID: " + playerID;
    }

    public void OnSubmit()
    {
        playerUserName = nameText.text;
        PostToDatabase();
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Post("https://farwees-u29-default-rtdb.firebaseio.com/.json", user);
    }

}
