using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSafeCheck : MonoBehaviour
{

    public static bool isPlayerSafe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        isPlayerSafe = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerSafe = false;
    }
}
