using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnimator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 50;

    //saldiri zamanini sinirlamak icin, mousea art arda bastikca her seferinde attacki engellemek icin
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRange; //saniyede sadece 2kez saldirabilir
            }
        }
    }

    void Attack()
    {
        //play an attack animation
        playerAnimator.SetBool("IsShield", true);

        // detect enemies in range of attack
        //bu attackpoint diye olusturdugumuz noktada daire olusturuyor ve bu dairenin carptigi nesneleri topluyor
        //2D icin boyle
        //Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //3D icinse 
        //vurdugumuz tum dusmanlari bu listede tutuyoruz
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //damage them
        foreach(Collider enemy in hitEnemies)
        {
            //vurdugumuz dusmanin adini soyluyor
            //Debug.Log("We hit " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    //burasi gerekli degil, gormek icin sadece(build almadan silinebilir)
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
