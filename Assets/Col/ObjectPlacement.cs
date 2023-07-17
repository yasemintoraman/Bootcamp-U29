using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public Transform[] DropAreas; // 4 obje yeri
    public GameObject fifthObject; // 5. obje
    public GameObject[] dropareas;
    public GameObject[] sculptures;

    public bool isSuccess = false;


    public float minY = -1.78f;
    public float maxY = 1.5f;
    public float moveSpeed = 1.0f;




    private void Start()
    {
        fifthObject = GameObject.Find("fifthObject");

        sculptures = new GameObject[4];
        sculptures[0] = GameObject.Find("Statue_Cat (3)");
        sculptures[1] = GameObject.Find("Statue_Cat (4)");
        sculptures[2] = GameObject.Find("Statue_Cat (5)");
        sculptures[3] = GameObject.Find("Statue_Cat (6)");

        dropareas = new GameObject[8];
        dropareas[0] = GameObject.Find("DropArea1");
        dropareas[1] = GameObject.Find("DropArea2");
        dropareas[2] = GameObject.Find("DropArea3");
        dropareas[3] = GameObject.Find("DropArea4");
        dropareas[4] = GameObject.Find("DropArea5");
        dropareas[5] = GameObject.Find("DropArea6");
        dropareas[6] = GameObject.Find("DropArea7");
        dropareas[7] = GameObject.Find("DropArea8");
    }
    private void Update()
    {
        //CheckObjectPlacement();
    }
    private void FixedUpdate()
    {
        CheckObjectPlacement();
        MoveFifthObject();
    }

    private void CheckObjectPlacement()
    {

        if (sculptures[0].transform.position.x == dropareas[0].transform.position.x &&
                sculptures[1].transform.position.x == dropareas[3].transform.position.x &&
                sculptures[2].transform.position.x == dropareas[5].transform.position.x &&
                sculptures[3].transform.position.x == dropareas[6].transform.position.x)
        {
            isSuccess = true;
            Debug.Log("basarili");

            }
        else
        {
            isSuccess = false;
            Debug.Log("tekrar dene!!1");
            }

    }

    private bool ObjectExistsAtSpot(int index)
    {
        // Ýlgili objenin konumu üzerinde baþka bir obje var mý kontrol edilir
        Collider[] colliders = Physics.OverlapSphere(DropAreas[index].position, 0.5f);

        // Eðer hiçbir obje yoksa false döner, aksi halde true döner
        return colliders.Length > 0;
    }

    private void MoveFifthObject()
    {
        if (isSuccess)
        {

            Vector3 direction = Vector3.down;
            float moveAmount = moveSpeed * Time.deltaTime;
            Vector3 newPosition = fifthObject.transform.position + direction * moveAmount;
            fifthObject.transform.position = newPosition;
            if (fifthObject.transform.position.y <= minY)
                fifthObject.SetActive(false);
        }
    }

}