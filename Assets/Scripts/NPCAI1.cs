using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI : MonoBehaviour
{

    public NavMeshAgent _agent; //unityengine.ai
    [SerializeField] Transform _player;
    public LayerMask ground, player; //belirli layerlarda hareketini kontrol etmek icin

    public Vector3 destinationPoint; //yuruyus noktasi
    private bool destinationPointSet;
    public float walkPointRange;  //hareket edebilecegimiz mesafe

    public float timeBetweenAttacks; //attackler arasi zaman
    private bool alreadyAttacked = true;  //attack yapip yapmadigimiz kontrol etmek icin
    public GameObject sphere; //saldirmak icin sphere atmak gibi

    public float sightRange, attackRange; //gorus alani, saldiri alani
    public bool playerInSightRange, playerInAttackRange;

    private Animator animator;
    private List<string> animations;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int attackDamage;

    private void Start()
    {

        animator = GetComponent<Animator>();
        animations = new List<string>()
            {
                "Hit1",
                "Fall1",
                "Attack1",
            };
    }

    private void Awake() //oyun basladiginda
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

        //destinationpointe gidip gitmedigini kontrol etmek icin
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

        destinationPoint = new Vector3(transform.position.x + randomX, -transform.position.y, transform.position.z + randomZ);

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


        transform.LookAt(_player);

        animator.SetBool("attack1", true);
        animator.SetBool("attack2", true);

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach (Collider enemy in hitEnemies)
        {
            //vurdugumuz dusmanin adini soyluyor
            //Debug.Log("We hit " + enemy.name);
          
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
             
        }
        /*
        if (!alreadyAttacked)
        {
            //logic
            //karakterin bir seyler firlattigi bir logic
            Rigidbody rb = Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //forward dedigimizde baktigimiz tarafa dogru
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse); //ileri
            rb.AddForce(transform.up * 7f, ForceMode.Impulse); //yukari

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); //bir daha atak yapabilir hale gelir
        
        }*/

        Invoke(nameof(ResetAttack), timeBetweenAttacks * Time.deltaTime);

    }

    void ResetAttack() //atagi durdururuz
    {
        alreadyAttacked = false;
    }

    


}
