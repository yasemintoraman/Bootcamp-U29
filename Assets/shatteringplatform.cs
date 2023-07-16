using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct PieceInfo
{
    public Vector3 startPosition;
    public Quaternion startRotation;

    public Transform transform;
    public Rigidbody rigidbody;

    public PieceInfo(Vector3 startPosition, Quaternion startRotation, Transform transform, Rigidbody rigidbody)
    {
        this.startPosition = startPosition;
        this.startRotation = startRotation;
        this.transform = transform;
        this.rigidbody = rigidbody;
    }
}


public class shatteringplatform : MonoBehaviour
{
    public float waitTime;
    public float respawnTime;

    public float minForce;
    public float maxForce;

    private List<PieceInfo> _pieces = new List<PieceInfo>();
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            PieceInfo info = new PieceInfo(t.position, t.rotation, t, t.gameObject.GetComponent<Rigidbody>());
            _pieces.Add(info);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(BreakPlatform());
        }
    }

    private IEnumerator BreakPlatform()
    {
        yield return new WaitForSeconds(waitTime);

        foreach (PieceInfo piece in _pieces)
        {
            piece.rigidbody.isKinematic = false;

            float x = Random.Range(minForce, maxForce);
            float y = Random.Range(minForce, maxForce);
            float z = Random.Range(minForce, maxForce);

            piece.rigidbody.AddForce(x, y, z, ForceMode.Force);
        }

        yield return new WaitForSeconds(respawnTime);

        foreach (PieceInfo piece in _pieces)
        {
            piece.rigidbody.isKinematic = true;
            piece.transform.position = piece.startPosition;
            piece.transform.rotation = piece.startRotation;
        }
    }
}
