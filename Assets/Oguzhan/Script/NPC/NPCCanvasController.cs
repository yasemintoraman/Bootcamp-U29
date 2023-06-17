using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject npcCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcCanvas.SetActive(false);
        }

    }
}
