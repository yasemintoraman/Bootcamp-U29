using UnityEngine;

public class HeykelKontrol : MonoBehaviour
{
    public GameObject[] heykelObjeListesi;
    public GameObject[] heykelYuvasiListesi;
    public GameObject tetiklenecekObj;

    private int heykelSayac = 0;
    private bool heykelYerlestirildi = false;
    public float minY = -1.77f;
    public float maxY = 1.42f;
    public float moveSpeed = 1.0f;

    private void Start()
    {
        tetiklenecekObj = GameObject.Find("tetiklenecekObj");

        heykelObjeListesi = new GameObject[2];
        heykelObjeListesi[0] = GameObject.Find("heykelObje1"); // �lk heykelin ad�n� buraya yaz�n veya hiyerar�ideki ad�na g�re de�i�tirin
        heykelObjeListesi[1] = GameObject.Find("heykelObje2"); // �kinci heykelin ad�n� buraya yaz�n veya hiyerar�ideki ad�na g�re de�i�tirin

        heykelYuvasiListesi = new GameObject[2];
        heykelYuvasiListesi[0] = GameObject.Find("HeykelYuvasi1"); // �lk heykel yuvas�n�n ad�n� buraya yaz�n veya hiyerar�ideki ad�na g�re de�i�tirin
        heykelYuvasiListesi[1] = GameObject.Find("HeykelYuvasi2"); // �kinci heykel yuvas�n�n ad�n� buraya yaz�n veya hiyerar�ideki ad�na g�re de�i�tirin
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == heykelObjeListesi[heykelSayac])
        {
            heykelObjeListesi[heykelSayac].transform.position = heykelYuvasiListesi[heykelSayac].transform.position;
            heykelObjeListesi[heykelSayac].transform.rotation = heykelYuvasiListesi[heykelSayac].transform.rotation;
            heykelObjeListesi[heykelSayac].GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log(heykelSayac);
            heykelSayac++;
            Debug.Log(heykelSayac);
            if (heykelSayac >= heykelObjeListesi.Length)
            {
                heykelYerlestirildi = true;
                //Tetikle();
            }
        }
    }
    private void FixedUpdate()
    {
        Tetikle();
    }
    private void Tetikle()
    {
        //Debug.Log("calisti");
        if (heykelYerlestirildi)
        {
            // Rigidbody rb = tetiklenecekObj.GetComponent<Rigidbody>();
            //rb.useGravity = true;

            Vector3 direction = Vector3.down;
            float moveAmount = moveSpeed * Time.deltaTime;
            Vector3 newPosition = tetiklenecekObj.transform.position + direction * moveAmount;
            tetiklenecekObj.transform.position = newPosition;
            if (tetiklenecekObj.transform.position.y <= minY)
                tetiklenecekObj.SetActive(false);

        }
    }
}
