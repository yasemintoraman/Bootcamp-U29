using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI2 : MonoBehaviour
{
    [SerializeField] private GameObject destinationPoint;

    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(destinationPoint.transform.position);
    }
}
