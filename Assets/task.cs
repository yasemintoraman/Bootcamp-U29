using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task : MonoBehaviour
{
    public Text yazi_1, yazi_2, yazi_3, yazi_4, yazi_5;
    public bool gorev, gorev_kabul, gorev_aktif;
    public float sure;
    public GameObject sepet, baslangic;
    public int para, ucret;

    void Start()
    {
        baslangic = GameObject.FindGameObjectWithTag("basla");
        sure = 20f;
        gorev = false;
        gorev_aktif = false;
        gorev_kabul = false;
        yazi_1.text = sure.ToString();
        yazi_2.text = "Görev";
        yazi_3.text = "";
        yazi_4.text = "";
        yazi_5.text = "";
        sepet.SetActive(false);

    }

    void Update()
    {
        

        if (gorev_kabul == true && Input.GetKeyDown(KeyCode.N))
        {
            gorev_aktif = false;
            yazi_3.text = "";
            yazi_4.text = "";
        }

        if (gorev_kabul == true && Input.GetKeyDown(KeyCode.Y))
        {
            gorev_aktif = true;
            yazi_3.text = "";
            yazi_4.text = "";
            ucret = 50;
        }

        if (gorev_aktif == true)
        {
            yazi_1.text = sure.ToString();
            sepet.SetActive(true);

            //sure durumu
            if (gorev == true)
            {

            }

            else if (sure > 0)
            {
                sure -= 1 * Time.deltaTime;
            }

            else
            {
                sure = 0;
            }

            //basarý durumu
            if (gorev == true && sure > 0)
            {
                yazi_2.text = "GÖREV TAMAMLANDI";
                para += ucret;
                ucret = 0;
                sepet.SetActive(false);
                baslangic.SetActive(false);
            }

            else if (sure <= 0)
            {
                yazi_2.text = "GÖREV BAÞARISIZ";
                sepet.SetActive(false);
                gorev = false;
                gorev_aktif = false;
                gorev_kabul = false;
            }

        }

        Debug.Log(sure);
    }

    void OnTriggerEnter(Collider temas)
    {
        if (temas.gameObject.tag == "basla")
        {
            sure = 20;
            yazi_2.text = "GÖREV OBJELERÝ 20SN ÝÇÝNDE TOPLAMAK";
            yazi_3.text = "Kabul etmek için Y'ye bas.";
            yazi_4.text = "Reddetmek için N'ye bas.";
            gorev_kabul = true;
        }

        if (temas.gameObject.tag == "hedef" && gorev_aktif == true)
        {
            gorev = true;
        }
    }

    void OnTriggerExit(Collider ayril)
    {
        if (ayril.gameObject.tag == "basla")
        {
            yazi_2.text = "Görev";
            yazi_3.text = "";
            yazi_4.text = "";
        }
    }
}


