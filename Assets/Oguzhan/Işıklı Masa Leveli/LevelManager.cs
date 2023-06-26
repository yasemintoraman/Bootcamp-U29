using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform levelStartPosition;
    [SerializeField] private GameObject mainPlayer;
    [SerializeField] private int healthPlayer = 1;
    private float timer;
    [SerializeField] private GameObject takingDamageEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CamFollowPlayer.camPositionValue == 1)
        {

            if (!LightMechanic.IsLightClosed && !PlayerSafeCheck.isPlayerSafe)
            {
                timer += Time.deltaTime;
                takingDamageEffect.SetActive(true);
                if (timer >= 1)
                {
                    healthPlayer--;
                    timer = 0;
                }
            }
            else if (LightMechanic.IsLightClosed || PlayerSafeCheck.isPlayerSafe)
            {
                timer = 0;
                takingDamageEffect.SetActive(false);
            }
            if (healthPlayer == 0)
            {
                mainPlayer.transform.position = levelStartPosition.position;
                healthPlayer = 1;
            }
        }

        else if (CamFollowPlayer.camPositionValue == 0)
        {
            takingDamageEffect.SetActive(false);
        }
        Debug.Log(timer);
    }
}
