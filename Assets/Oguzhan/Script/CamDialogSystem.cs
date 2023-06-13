using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamDialogSystem : MonoBehaviour
{
    [SerializeField] private float speedCameraMovement;
    private GameObject mainCamera;
    private GameObject mainPlayer;
    private Vector3 playerPosition;
    [SerializeField] private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F bastý");
            playerPosition = other.transform.position;
            StartCoroutine(StartDialog());
        }
    }


    private IEnumerator  StartDialog()
    {
        float travelPercent = 0f;
        while (travelPercent < 1f)
        {
            travelPercent += Time.deltaTime * speedCameraMovement;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,transform.position + targetPosition, travelPercent);
            Debug.Log(travelPercent);
            yield return new WaitForEndOfFrame();
            
        }
       
    }
}
