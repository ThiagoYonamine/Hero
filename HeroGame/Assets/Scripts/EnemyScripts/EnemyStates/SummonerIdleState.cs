using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerIdleState : IEnemyState
{
    private float _secondsSummon = 2;
    private float _timerSummon = 0;

    private float _secondsIdle = 6;
    private float _timerIdle = 0;
    public IEnemyState DoState(Enemy enemy)
    {
        var summoner = (SummonerEnemy)enemy;
        float passedTime = Time.deltaTime;
        
        _timerIdle += passedTime;
        _timerSummon += passedTime;

        if (_timerIdle < _secondsIdle)
        {
            Idle(summoner);
            Summon(summoner);

            return summoner.summonerIdleState;
        }
        else
        {
            MoveToRun(summoner);
            return summoner.summonerRunAwayState;
        }
    }

    void Idle(SummonerEnemy enemy)
    {
        enemy.Animator.SetBool(SummonerEnemy.runningAnimation, false);
    }

    void Summon(SummonerEnemy enemy)
    {
        if (_timerSummon >= _secondsSummon)
        {
            _timerSummon = 0;
            enemy.Animator.SetTrigger(SummonerEnemy.summonAnimation);
        }
    }

    void MoveToRun(SummonerEnemy enemy)
    {
        _timerIdle = 0;
        _timerSummon = 0;
        enemy.Animator.ResetTrigger(SummonerEnemy.summonAnimation);
    }
}
