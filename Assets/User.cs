using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class User 
{
    public string userName;
    public int userScore;

    public User()
    {
        userName = PlayerScores.playerName;
        userScore = PlayerScores.playerScore;

    }
}
