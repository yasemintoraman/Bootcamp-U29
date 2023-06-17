using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamDialogSystem : MonoBehaviour
{
    [SerializeField] GameObject camPoint;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] private static GameObject speakerNPC;
    [SerializeField] private float speedCameraMovement;
    private static Vector3 camStartPosition;
    private GameObject mainCamera;
    private Vector3 playerPosition;
    private Vector3 targetPosition;

    [SerializeField] private int speakCount;
    [SerializeField] private int speakIndex;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        targetPosition = camPoint.transform.position;
        camStartPosition = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DialogSystemCheck();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            speakIndex = 0;
            speakerNPC = gameObject;
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
        if (speakerNPC.GetComponent<CamDialogSystem>().speakIndex % 2 == 0)
        {
            mainCamera.transform.LookAt(speakerNPC.transform);
        }
        if (speakerNPC.GetComponent<CamDialogSystem>().speakIndex % 2 == 1)
        {
            mainCamera.transform.LookAt(mainPlayer.transform);
        }

        if (Input.GetKeyDown(KeyCode.Z) && transform.name == speakerNPC.name)
        {
            speakIndex++;
            Debug.Log(speakIndex);
        }
    }


    private void DialogSystemCheck()
    {
        if (GameManager.IsDialogStarted)
        {
            DialogSystem();
            if (speakIndex == speakCount)
            {
                Debug.Log("if içine girdi");
                speakIndex = 0;
                StartCoroutine(ExitDialog());
            }
        }
    }


    public IEnumerator ExitDialog()
    {
        float travelPercent = 0f;
        while (travelPercent < 0.33f)
        {
            travelPercent += Time.deltaTime * speedCameraMovement;
            Debug.Log(travelPercent);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, mainPlayer.transform.position + mainCamera.GetComponent<CamFollowPlayer>().cameraPosition, travelPercent);
            yield return new WaitForEndOfFrame();
        }
        GameManager.IsDialogStarted = false;

    }

}
