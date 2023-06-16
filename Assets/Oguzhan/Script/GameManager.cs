using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsDialogStarted;
    [SerializeField] private GameObject mainPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        IsDialogStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
