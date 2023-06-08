using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    private Vector3 playerPosition;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerPosition = transform.position;
            //targetPosition
        }
    }
}
