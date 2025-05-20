using System.Collections.Generic;
using Enemy;
using Player;
using ScObjects;
using UnityEngine;

namespace EnemySpawner
{
    public class EnemySpawnerScript : MonoBehaviour
    {
        [SerializeField] private EnemyWaveScript wave;
        [SerializeField] private EnemyWaveScript bossWave;
        [SerializeField] private List<Vector3> positions;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private PlayerScript player;
        [SerializeField] private double waveDelayTime;
        [SerializeField] private int waveEnemyCountShift;

        private int currentWave;
        private double waveTimer;

        private void Start() => CurrentValues.ClearEnemies();

        private void StartWaveTimer() => waveTimer = waveDelayTime;

        private void Update()
        {
            if (CurrentValues.EnemyCount == 0 && waveTimer <= 0) 
                StartWaveTimer();
            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
                if (waveTimer <= 0)
                    SpawnWave();
            }
        }

        private void SpawnWave()
        {
            var enemySpawnCount = Random.Range(4 + currentWave / waveEnemyCountShift, 8 + currentWave / waveEnemyCountShift);
            var newWave = new List<EnemyScObject>();
            var positionCounter = 0;
            for (int i = 0; i < enemySpawnCount; i++)
            {
                var enemyId = Random.Range(0, wave.Enemies.Count);
                newWave.Add(wave.Enemies[enemyId]);
            }

            if (currentWave % 5 == 0)
            {
                newWave.Add(bossWave.Enemies[0]);
            }
            
            foreach (var enemyScObject in newWave)
            {
                var enemyInstance = Instantiate(enemyPrefab, positions[positionCounter], new Quaternion(0,0,0,0));
                var enemyScript = enemyInstance.GetComponent<EnemyScript>();
                enemyScript.SetScObject(enemyScObject);
                enemyScript.Target = player;
                positionCounter++;
                if (positionCounter >= positions.Count)
                    positionCounter = 0;
            }

            currentWave++;
        }
    }
}