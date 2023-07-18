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
    public Image dialogTextBackGround;
    [SerializeField] GameObject camPoint;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] private static GameObject speakerNPC;
    [SerializeField] private float speedCameraMovement;
    public static Vector3 camStartPosition;
    public GameObject mainCamera;
    public Vector3 playerPosition;
    public Vector3 targetPosition;
    public Animator playerAnimator;

    [SerializeField] private int speakCount;
    [SerializeField] private int speakIndex;
    [SerializeField] private int konusmaSirasi;
    [SerializeField] string[] diyalogBaloons;
    [SerializeField] string[] diyalogBaloons2;

    void Start()
    {
        dialogTextBackGround = GameObject.Find("DialogTextBackGround").GetComponent<Image>();
        dialogText = GameObject.Find("DiyalogText").GetComponent<TextMeshProUGUI>();
        mainCamera = GameObject.Find("Main Camera");
        camStartPosition = mainCamera.transform.position;
        playerAnimator = mainPlayer.GetComponentInChildren<Animator>();
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


            if (gameObject.tag == "Gorev3")
            {
                GameManager.currentMissionIndex = 7;
            }

            else if (gameObject.tag == "Gorev1" && GameManager.currentMissionIndex == 2)
            {
                GameManager.currentMissionIndex = 3;
            }


            else if (gameObject.tag == "Gorev2" && GameManager.currentMissionIndex == 5)
            {
                GameManager.currentMissionIndex = 6;
            }

            else if (gameObject.tag == "Gorev2")
            {
                GameManager.currentMissionIndex = 4;
            }


            else if (gameObject.tag == "Gorev1")
            {
                GameManager.currentMissionIndex = 1;
            }


        }
    }

    private IEnumerator StartDialog()
    {

        GameManager.IsDialogStarted = true;
        dialogText.enabled = true;
        dialogTextBackGround.enabled = true;
        playerAnimator.SetFloat("Blend",0);
        speakerNPC.transform.LookAt(mainPlayer.transform);
        mainPlayer.transform.LookAt(speakerNPC.transform);
        targetPosition = camPoint.transform.position;
        float travelPercent = 0f;
        while (travelPercent < 1f)
        {
            travelPercent += Time.deltaTime * speedCameraMovement;
            mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, targetPosition, travelPercent);
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

        if (speakerNPC.GetComponent<CamDialogSystem>().konusmaSirasi == 0)
        {
            dialogText.text = speakerNPC.GetComponent<CamDialogSystem>().diyalogBaloons[speakerNPC.GetComponent<CamDialogSystem>().speakIndex];
        }
        else if (speakerNPC.GetComponent<CamDialogSystem>().konusmaSirasi == 1)
        {
            dialogText.text = speakerNPC.GetComponent<CamDialogSystem>().diyalogBaloons2[speakerNPC.GetComponent<CamDialogSystem>().speakIndex];
        }


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
            if (speakIndex == speakCount && speakerNPC.GetComponent<CamDialogSystem>().konusmaSirasi == 0)
            {
                speakIndex = 0;
                speakerNPC.GetComponent<CamDialogSystem>().konusmaSirasi = 1;
                StartCoroutine(ExitDialog());
            }
            else if (speakIndex == speakerNPC.GetComponent<CamDialogSystem>().diyalogBaloons2.Length && speakerNPC.GetComponent<CamDialogSystem>().konusmaSirasi == 1)
            {
                speakIndex = 0;
                StartCoroutine(ExitDialog());
            }
        }
    }


    public IEnumerator ExitDialog()
    {
        dialogText.enabled = false;
        dialogTextBackGround.enabled = false;
        float travelPercent = 0f;
        while (travelPercent < 0.33f)
        {
            travelPercent += Time.deltaTime * speedCameraMovement;
            mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, mainPlayer.transform.position + mainCamera.GetComponent<CamFollowPlayer>().cameraPositionIsometric, travelPercent);
            yield return new WaitForEndOfFrame();
        }
        GameManager.IsDialogStarted = false;

    }

}
