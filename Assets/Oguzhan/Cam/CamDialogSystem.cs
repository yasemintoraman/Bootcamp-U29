using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class CamDialogSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] GameObject camPoint;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] private static GameObject speakerNPC;
    [SerializeField] private float speedCameraMovement;
    private static Vector3 camStartPosition;
    private GameObject mainCamera;
    private Vector3 playerPosition;
    private Vector3 targetPosition;
    private Animator playerAnimator;

    [SerializeField] private int speakCount;
    [SerializeField] private int speakIndex;
    [SerializeField] string[] diyalogBaloons;

    void Start()
    {
        dialogText = GameObject.Find("DiyalogText").GetComponent<TextMeshProUGUI>();
        mainCamera = GameObject.Find("Main Camera");
        camStartPosition = mainCamera.transform.position;
        playerAnimator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        speakCount = diyalogBaloons.Length;
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
            Debug.Log("TriggerStayÇalýþtý");
            speakerNPC = gameObject;
            playerPosition = mainPlayer.transform.position;
            StartCoroutine(StartDialog());
        }
    }

    private IEnumerator StartDialog()
    {

        GameManager.IsDialogStarted = true;
        dialogText.enabled = true;
        playerAnimator.SetFloat("Blend",0);
        speakerNPC.transform.LookAt(mainPlayer.transform);
        mainPlayer.transform.LookAt(speakerNPC.transform);
        targetPosition = camPoint.transform.position;
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
        dialogText.text = speakerNPC.GetComponent<CamDialogSystem>().diyalogBaloons[speakerNPC.GetComponent<CamDialogSystem>().speakIndex];


        if (Input.GetMouseButtonDown(0) && transform.name == speakerNPC.name)
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
                speakIndex = 0;
                StartCoroutine(ExitDialog());
            }
        }
    }


    public IEnumerator ExitDialog()
    {
        dialogText.enabled = false;
        float travelPercent = 0f;
        while (travelPercent < 0.33f)
        {
            travelPercent += Time.deltaTime * speedCameraMovement;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, mainPlayer.transform.position + mainCamera.GetComponent<CamFollowPlayer>().cameraPositionIsometric, travelPercent);
            yield return new WaitForEndOfFrame();
        }
        GameManager.IsDialogStarted = false;

    }

}
