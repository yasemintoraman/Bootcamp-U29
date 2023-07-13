using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class LightMechanic : MonoBehaviour
{
    [SerializeField] private GameObject lightMechanicObject;
    public static bool IsLightClosed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && IsLightOpen())
        {
            StartCoroutine(CloseTheLiight());
        }
    }

    private void CloseLight()
    {
        lightMechanicObject.SetActive(true);
        IsLightClosed = true;
    }
    private void OpenLight()
    {
        lightMechanicObject.SetActive(false);
        IsLightClosed = false;
    }

    private bool IsLightOpen()
    {
        if (lightMechanicObject.activeInHierarchy)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator CloseTheLiight()
    {
        CloseLight();
        yield return new WaitForSeconds(3f);
        OpenLight(); 
    }
}
