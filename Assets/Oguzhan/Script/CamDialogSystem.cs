using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamDialogSystem : MonoBehaviour
{
    [SerializeField] GameObject camPoint;
    [SerializeField] private float speedCameraMovement;
    private GameObject mainCamera;
    private GameObject mainPlayer;
    private Vector3 playerPosition;
    private Vector3 targetPosition;
    [SerializeField] private int speakCount;
    private int speakIndex;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        targetPosition = camPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsDialogStarted)
        {
            DialogSystem();
            if (speakIndex >= speakCount)
            {
                speakIndex = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            mainPlayer = other.gameObject;
            playerPosition = mainPlayer.transform.position;
            StartCoroutine(StartDialog());
        }
    }


    private IEnumerator StartDialog()
    {
        GameManager.IsDialogStarted = true;
        float travelPercent = 0f;
        while (travelPercent < 1f)
        {
            travelPercent += Time.deltaTime * speedCameraMovement;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, travelPercent);
            yield return new WaitForEndOfFrame();
        }
    }

    private void DialogSystem()
    {
        if (speakIndex % 2 == 0)
        {
            mainCamera.transform.LookAt(transform);
        }
         if (speakIndex % 2 == 1)
        {
            mainCamera.transform.LookAt(mainPlayer.transform);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            speakIndex++;
            Debug.Log(speakIndex);
        }
    }
}
