using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AslanController : MonoBehaviour
{
    public static int aslanCount;
    public TextMeshProUGUI gorevText;
    public GameObject ok;
    public GameObject portal;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            aslanCount++;
            if (aslanCount >= 5)
            {
                gorevText.text = "Portala ulaþ";
            }
        }
    }
}
