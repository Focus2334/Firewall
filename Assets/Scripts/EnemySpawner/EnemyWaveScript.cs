using ScObjects;
using UnityEngine;
using System.Collections.Generic;

namespace EnemySpawner
{
    [CreateAssetMenu(fileName = "New EnemyWave", menuName = "EnemyWave Data", order = 53)]
    public class EnemyWaveScript : ScriptableObject
    {
        [SerializeField] private List<EnemyScObject> enemies;

        public List<EnemyScObject> Enemies => enemies;
    }
}