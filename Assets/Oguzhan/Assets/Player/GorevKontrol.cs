using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorevKontrol : MonoBehaviour
{
    public static int odunCount;
    public static int samanCount;
    public static int yemisCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentMissionIndex == 1 && odunCount >= 5)
        {
            GameManager.currentMissionIndex = 2;
        }
        else if (GameManager.currentMissionIndex == 4 && samanCount >= 5)
        {
            GameManager.currentMissionIndex = 5;
        }
        else if (GameManager.currentMissionIndex == 7 && yemisCount >= 5)
        {
            GameManager.currentMissionIndex = 8;
        }
    }
}
