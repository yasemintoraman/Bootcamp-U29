using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public int missionIndex { get; set; }
    public string missionContent { get; set; }
    public bool missionStatus { get; set; }
    public Transform missionPosition { get; set; }
}
