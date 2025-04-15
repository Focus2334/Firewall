using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New EnemyWave", menuName = "EnemyWave Data", order = 53)]
public class EnemyWaveScript : ScriptableObject
{
    [SerializeField] private List<EnemyScObject> enemies;

    public List<EnemyScObject> Enemies { get { return enemies; } }
}
