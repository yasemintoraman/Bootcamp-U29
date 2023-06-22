using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject mainCamera;
    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera.transform.position,Vector3.down);        
    }
}
