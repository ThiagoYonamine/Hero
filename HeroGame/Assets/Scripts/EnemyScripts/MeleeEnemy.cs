using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float stopDistance;


    float timerAttack;
    private void Update()
    {
        if (Player == null) return;

        timerAttack += Time.deltaTime;
        if (Vector2.Distance(transform.position, Player.position) <= stopDistance)
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
            Player.GetComponent<Player>().TakeDamage(damage);
            StartCoroutine(nameof(AttackAnimation));
        }
    }

    void Move()
    {
        //var runAway = transform.position - player.position;
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
    }

    IEnumerator AttackAnimation()
    {
        Vector2 target = Player.position;
        Vector2 origin = transform.position;
        float progress = 0;
        while (progress <= 1)
        {
            progress += Time.deltaTime * attackAnimationSpeed;
            float curve = (-Mathf.Pow(progress, 2) + progress) * 4;
            transform.position = Vector2.Lerp(origin, target, curve);
            yield return null;
        }
    }
}
