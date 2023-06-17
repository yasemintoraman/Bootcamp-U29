using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private GameObject mainPlayer;
    private GameObject mainCamera;
    // Update is called once per frame
    private void Awake()
    {
        transform.position = mainPlayer.transform.position + cameraPosition;
    }
    private void Start()
    {
        mainCamera = gameObject;
    }
    private void LateUpdate()
    {
        if (GameManager.IsDialogStarted == false)
        {
            mainCamera.transform.position = mainPlayer.transform.position + cameraPosition;
            mainCamera.transform.LookAt(mainPlayer.transform);
        }
    }
}
