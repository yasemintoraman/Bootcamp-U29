using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] public Vector3 cameraPositionIsometric;
    [SerializeField] public Vector3 cameraPositionTwoandHalf;


    public static int camPositionValue;
    [SerializeField] private GameObject mainPlayer;
    private GameObject mainCamera;
    // Update is called once per frame

    private void Awake()
    {
        transform.position = mainPlayer.transform.position + cameraPositionIsometric;
    }
    private void Start()
    {
        mainCamera = gameObject;
    }
    private void LateUpdate()
    {
        switch (camPositionValue)
        {
            case 0:
                {
                    IsometricCamPosition();
                    break;
                }
            case 1:
                {
                    TwoandHalfCamPosition();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }


    private void IsometricCamPosition()
    {
        if (GameManager.IsDialogStarted == false)
        {
            mainCamera.transform.position = mainPlayer.transform.position + cameraPositionIsometric;
            mainCamera.transform.LookAt(mainPlayer.transform);
        }
    }

    private void TwoandHalfCamPosition()
    {
        if (GameManager.IsDialogStarted == false)
        {
            mainCamera.transform.position = mainPlayer.transform.position + cameraPositionTwoandHalf;
            mainCamera.transform.LookAt(mainPlayer.transform);
        }
    }
}
