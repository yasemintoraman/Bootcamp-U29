using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && CompareTag("Wood") && other.CompareTag("Player"))
        {
            GorevKontrol.odunCount++;
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.E) && CompareTag("Saman") && other.CompareTag("Player"))
        {
            GorevKontrol.samanCount++;
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.E) && CompareTag("Yemis") && other.CompareTag("Player"))
        {
            GorevKontrol.yemisCount++;
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.E) && CompareTag("Comlek") && other.CompareTag("Player"))
        {
            ColLevelController.comlekCount++;
            Destroy(gameObject);
        }
    }
}
