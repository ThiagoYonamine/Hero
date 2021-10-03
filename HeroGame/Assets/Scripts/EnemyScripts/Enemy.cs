using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _life;
    [SerializeField] int _speed;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float attackAnimationSpeed;
    [SerializeField] protected int damage;

    protected IEnemyState CurrentState { get; set; }
    public Animator Animator { get; private set; }
    public Transform Player { get; private set; }
    public int Speed => _speed;

    public int Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
            if (_life <=0 )
            {
                //Todo change destroy
                Destroy(this.gameObject);
            }
        }
    }

    public virtual void Start()
    {
        //todo change
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Animator = this.GetComponent<Animator>();
        Init();
    }

    protected virtual void Init() { }

    //todo, trocar por outro pattern? 
    public void TakeDamage(int damageAmount)
    {
        Life -= damageAmount;
    }
}

