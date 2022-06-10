using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackCD;
    private float cdTimer;
    private Animator anim;
    //range atk
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range; // chi?u dài vùng t?n công
    [SerializeField] private float colliderDistance; // < 1 ?? ?i?u ch?nh kho?ng cách vùng t?n công
    [SerializeField] private LayerMask enemyLayer;

    private HealthEnemy enemyHealth;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cdTimer > attackCD)
        {
            Attack();

        }
        EnemyInSight();
        cdTimer += Time.deltaTime;
        //Debug.Log(EnemyInSight());
    }
    private void Attack()
    {
        anim.SetTrigger("attack");

        cdTimer = 0;

    }
    //public void AddAtkSpd(float _spd)
   // {
       // attackCD = attackCD - _spd;
       // anim.SetTrigger("atkspeed");
    //}
    private bool EnemyInSight() // box hit
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        , 0, Vector2.left, 0, enemyLayer); 
        if (hit.collider != null)
            enemyHealth = hit.transform.GetComponent<HealthEnemy>(); //de hit truy cap vào Health

        return hit.collider != null;

    }
    private void OnDrawGizmos() // Draw box hit
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamageEnemy()
    {


        // - health enemy
        if (EnemyInSight())
            enemyHealth.TakeDamage(damage);

    }

}
