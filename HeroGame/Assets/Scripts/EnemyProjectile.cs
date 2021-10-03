using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] int _speed;

    public int Speed => _speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Player player = collision.GetComponent<Player>();
        player.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
