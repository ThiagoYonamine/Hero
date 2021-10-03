using UnityEngine;

public interface IEnemyState 
{
    IEnemyState DoState(Enemy enemy);
}
