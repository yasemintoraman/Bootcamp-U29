using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{


    float RotationSpeed = 100f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * RotationSpeed *  Time.deltaTime);
        }
        else if(other.CompareTag("Player") && Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * RotationSpeed * Time.deltaTime);
        }
        
    }

}
