using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerEnemy : Enemy
{
    [SerializeField] Enemy _enemyToSummon;
    //states
    public SummonerIdleState summonerIdleState = new SummonerIdleState();
    public SummonerRunAwayState summonerRunAwayState = new SummonerRunAwayState();

    //animations
    public static string runningAnimation = "running";
    public static string summonAnimation = "summon";

    protected override void Init()
    {
        CurrentState = summonerIdleState;
    }

    void Update()
    {
        if (Player == null) return;

        CurrentState = CurrentState.DoState(this);
    }

    public void CreateMinion()
    {
        Instantiate(_enemyToSummon, transform.position, transform.rotation);
    }
}
