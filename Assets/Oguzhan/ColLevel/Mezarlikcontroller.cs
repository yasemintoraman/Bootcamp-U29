using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mezarlikcontroller : MonoBehaviour
{
    public GameObject MezarlikStoryPanel;
    public TextMeshProUGUI gorevText;
    private bool isActiveMezarlik;
    public GameObject ok;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && isActiveMezarlik == false)
        {
            ok.SetActive(false);
            gorevText.text = "Heykelleri bul, portalý aktif hale getir";
            isActiveMezarlik = true;
            StartCoroutine(PanelOnOff());
        }
        
    }


    IEnumerator PanelOnOff()
    {
        MezarlikStoryPanel.SetActive(true);
        yield return new WaitForSeconds(4f);
        MezarlikStoryPanel.SetActive(false);

        isActiveMezarlik = false;
    }

}
