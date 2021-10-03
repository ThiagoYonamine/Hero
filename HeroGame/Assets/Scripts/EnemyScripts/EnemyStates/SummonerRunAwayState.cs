using UnityEngine;

public class SummonerRunAwayState : IEnemyState
{
    private float _secondsRunning = 8;
    private float _timer = 0;

    public IEnemyState DoState(Enemy enemy)
    {
        var summoner = (SummonerEnemy)enemy;
        _timer += Time.deltaTime;
        if (_timer < _secondsRunning)
        {
            RunAway(summoner);
            return summoner.summonerRunAwayState;
        }
        else
        {
            MoveToIdle();
            return summoner.summonerIdleState;
        }
      
    }

    void RunAway(SummonerEnemy enemy)
    {
        enemy.Animator.SetBool(SummonerEnemy.runningAnimation, true);
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position,
            enemy.transform.position - enemy.Player.position,
            enemy.Speed * Time.deltaTime);
    }

    void MoveToIdle()
    {
        _timer = 0;
    }
}
