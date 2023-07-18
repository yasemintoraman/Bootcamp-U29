using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class User 
{
    public string userName;
    public int userID;

    public User()
    {
        userName = PlayerRegister.playerUserName;
        userID = PlayerRegister.playerID;

    }
}
