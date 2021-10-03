using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SOs/WaveConfiguration")]
public class WaveConfiguration : ScriptableObject
{
    [SerializeField] List<SpawnConfiguration> spawn;
    [SerializeField] float timePerSpawm;

    public List<SpawnConfiguration> Spawns => spawn;
    public float TimePerSpawm => timePerSpawm;



    [System.Serializable]
    public class SpawnConfiguration
    {
        public Enemy enemy;
        public int amount;
        public float timePerEnemy;
    }
}
