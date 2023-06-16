using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI2 : MonoBehaviour
{

    public NavMeshAgent _agent; //unityengine.ai
    [SerializeField] Transform _player;
    public LayerMask ground, player; //belirli layerlarda hareketini kontrol etmek icin

    public Vector3 destinationPoint; //yuruyus noktasi
    private bool destinationPointSet;
    public float walkPointRange;  //hareket edebilecegimiz mesafe

    public float timeBetweenAttacks;
    private bool alreadyAttacked;  //attack yapip yapmadigimiz kontrol etmek icin
    public GameObject sphere; 

    public float sightRange, attackRange; //gorus alani, saldiri alani
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //checksphere var olmayan bir collideri kullanabilmemizi saglar
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player); //belirli bir yerden sonra sightimda old fark edicem
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player); //cok fazla yaklastiktan sonra saldirmaya baslar


        //Patrol / Chase / Attack

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    void Patroling()
    {
        if (!destinationPointSet)
        {
            SearchWalkPoint();
        }

        if (destinationPointSet)
        {
            _agent.SetDestination(destinationPoint); //destinationpointe dogru git
        }

        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
        if(distanceToDestinationPoint.magnitude < 1.0f) //cok yaklastik o yuzden
        {
            destinationPointSet = false;
        }

    }

    void SearchWalkPoint()
    {
        //bizim verdigimiz rangelere gore rastgele yer hesaplariz
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(destinationPoint, -transform.up, 2.0f, ground)) //eger girmeye calistigim nokta grounddaysa
        {
            destinationPointSet = true;
        }
    }

    void ChasePlayer()
    {
        _agent.SetDestination(_player.position); //karakteri hareket ederek kovalar, yakalamaya calisir 
    }


    void AttackPlayer()
    {
        _agent.SetDestination(transform.position); //ates ederken npcnin hareket etmemesini saglariz

        transform.LookAt(_player);
        if (!alreadyAttacked)
        {
            //logic
            alreadyAttacked = true;
        }
    }

    void ResetAttack() //atagi durdururuz
    {
        alreadyAttacked = false;
    }



}
