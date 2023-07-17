using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZindanEntry : MonoBehaviour
{
    public GameObject bloomEfeckt;
    public Transform zindanEntryTarget;
    public TextMeshProUGUI missionText;
    public GameObject ok;
    public GameObject mezarlik;

    public static bool isEntertheZindan;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ColLevelController.comlekCount >= 5)
        {
            bloomEfeckt.SetActive(true);
            missionText.text = "Mezarlýktaki parþomeni bul";
            ok.SetActive(true);
            other.transform.position = zindanEntryTarget.position;
            isEntertheZindan = true;
        }
    }

    private void Update()
    {
        if (isEntertheZindan)
        {
            ok.transform.LookAt(mezarlik.transform.position);
        }
    }
}
