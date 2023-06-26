using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriggerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TwoandHalfAreaStart"))
        {
            CamFollowPlayer.camPositionValue = 1;
        }
        else if (other.CompareTag("TwoandHalfAreaEnd"))
        {
            CamFollowPlayer.camPositionValue = 0;
        }

    } 
}
