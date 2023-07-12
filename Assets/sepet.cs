using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sepet : MonoBehaviour
{
    public Transform Player, baglanti;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        baglanti = GameObject.FindGameObjectWithTag("bagla").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        transform.position = baglanti.transform.position;
    }
}
