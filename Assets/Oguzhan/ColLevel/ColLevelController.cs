using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColLevelController : MonoBehaviour
{
    public static int comlekCount;
    public GameObject okObject;
    public Transform targetPosition;
    private void Start()
    {
        comlekCount = 0;
    }

    private void Update()
    {
        if (comlekCount >= 5 && ZindanEntry.isEntertheZindan == false)
        {
            okObject.SetActive(true);
            okObject.transform.LookAt(targetPosition);

        }
    }
}
