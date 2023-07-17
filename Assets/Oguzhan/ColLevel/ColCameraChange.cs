using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCameraChange : MonoBehaviour
{
    public Camera mainCamera;
    public Camera displayCamera;
    public ObjectPlacement ObjectPlacement;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && ObjectPlacement.isSuccess)
        {
            displayCamera.enabled = false;
            mainCamera.enabled = true;
        }

        else if (other.CompareTag("Player"))
        {
            displayCamera.enabled = true;
            mainCamera.enabled = false;
        }
    }
}
