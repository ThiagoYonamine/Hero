using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] float rangeDistance;
    [SerializeField] Transform shotPoint;
    [SerializeField] EnemyProjectile bullet;

    float timerAttack;

    static string attackTrigger = "attack";
    private void Update()
    {
        if (Player == null) return;

        timerAttack += Time.deltaTime;
        if (Vector2.Distance(transform.position, Player.position) <= rangeDistance)
        {
            Attack();
        }
        else
        {
            Move();
        }

    }

    void Attack()
    {
        if (timerAttack >= attackDelay)
        {
            timerAttack = 0;
            // Player.GetComponent<Player>().TakeDamage(damage);
            // StartCoroutine(nameof(AttackAnimation));
            Animator.SetTrigger(attackTrigger);
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
    }

    public void AttackAnimation()
    {
        Vector2 direction = Player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        var bulletObject = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        bulletObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bullet.Speed);
    }
}
