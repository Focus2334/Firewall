using System.Collections.Generic;
using Enemy;
using Player;
using UnityEngine;

namespace EnemySpawner
{
    public class EnemySpawnerScript : MonoBehaviour
    {
        [SerializeField] private List<EnemyWaveScript> waves;
        [SerializeField] private List<Vector3> positions;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private PlayerScript player;
        [SerializeField] private double waveDelayTime;

        private int currentEnemiesCount;
        private int currentWave;
        private double waveTimer;

        private void Start() => SpawnWave();

        private void StartWaveTimer() => waveTimer = waveDelayTime;

        private void Update()
        {
            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
                if (waveTimer <= 0)
                    SpawnWave();
            }
        }

        private void SpawnWave()
        {
            if (currentWave >= waves.Count)
                return;

            var positionCounter = 0;
            foreach (var enemyScObject in waves[currentWave].Enemies)
            {
                var enemyInstance = Instantiate(enemyPrefab, positions[positionCounter], new Quaternion());
                var enemyScript = enemyInstance.GetComponent<EnemyScript>();
                enemyScript.SetScObject(enemyScObject);
                enemyScript.Target = player;
                currentEnemiesCount++;
                positionCounter++;
                if (positionCounter >= positions.Count)
                    positionCounter = 0;
            }

            currentWave++;
            StartWaveTimer();
        }
    }
}