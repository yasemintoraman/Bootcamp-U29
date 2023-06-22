using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentMissionIndex;
    public TextMeshProUGUI missionContentText;
    public static bool IsDialogStarted;
    [SerializeField] private GameObject mainPlayer;
    public List<Mission> missions = new List<Mission>();
    [SerializeField] Transform missionPosition1;
    [SerializeField] Transform missionPosition2;
    [SerializeField] Transform missionPosition3;
    [SerializeField] Transform missionPosition4;
    [SerializeField] Transform missionPosition5;
    [SerializeField] Transform missionPosition6;
    [SerializeField] Transform missionPosition7;
    [SerializeField] Transform missionPosition8;
    [SerializeField] Transform missionPosition9;
    Mission mission1;
    Mission mission2;
    Mission mission4;
    Mission mission3;
    Mission mission5;
    Mission mission6;
    Mission mission7;
    Mission mission8;
    Mission mission9;
    // Start is called before the first frame update
    private void Awake()
    {
        IsDialogStarted = false;
    }


    void Start()
    {
        currentMissionIndex = 0;
        mission1 = new Mission();
        mission2 = new Mission();
        mission4 = new Mission();
        mission3 = new Mission();
        mission5 = new Mission();
        mission6 = new Mission();
        mission7 = new Mission();
        mission8 = new Mission();
        mission9 = new Mission();


        mission1.missionIndex = 0;
        mission1.missionContent = "Dedeyle görüþ";
        mission1.missionStatus = false;
        mission1.missionPosition = missionPosition1;


        mission2.missionIndex = 1;
        mission2.missionContent = "Sepet yapabilmek için biraz odun topla";
        mission2.missionStatus = false;
        mission2.missionPosition = missionPosition2;


        mission3.missionIndex = 2;
        mission3.missionContent = "Dedeye geri dön";
        mission3.missionStatus = false;
        mission3.missionPosition = missionPosition3;


        mission4.missionIndex = 3;
        mission4.missionContent = "Artýk bir sepete sahipsin, þimdi yaban mersini toplamak için ormana git";
        mission4.missionStatus = false;
        mission4.missionPosition = missionPosition4;


        mission5.missionIndex = 4;
        mission5.missionContent = "Çakmaðý kullanarak ýþýklarý södür ve devlere yakalanmadan maðaradan kaç";
        mission5.missionStatus = false;
        mission5.missionPosition = missionPosition5;


        mission6.missionIndex = 5;
        mission6.missionContent = "Görev6";
        mission6.missionStatus = false;
        mission6.missionPosition = missionPosition6;


        mission7.missionIndex = 6;
        mission7.missionContent = "Görev7";
        mission7.missionStatus = false;
        mission7.missionPosition = missionPosition7;


        mission8.missionIndex = 7;
        mission8.missionContent = "Görev8";
        mission8.missionStatus = false;
        mission8.missionPosition = missionPosition8;


        mission9.missionIndex = 8;
        mission9.missionContent = "Görev9";
        mission9.missionStatus = false;
        mission9.missionPosition = missionPosition9;

        
        missions.Add(mission1);
        missions.Add(mission2);
        missions.Add(mission3);
        missions.Add(mission4);
        missions.Add(mission5);
        missions.Add(mission6);
        missions.Add(mission7);
        missions.Add(mission8);
        missions.Add(mission9);
    }

    // Update is called once per frame
    void Update()
    {
        missionContentText.text = "Görev: " + missions[currentMissionIndex].missionContent;

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentMissionIndex++;
        }
    }
}
