using System;
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
        [SerializeField] private EnemyWaveScript fwave;
        [SerializeField] private EnemyWaveScript bossWave;
        [SerializeField] private List<Vector3> positions;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private PlayerScript player;
        [SerializeField] private double waveDelayTime;
        [SerializeField] private int waveEnemyCountShift;

        private int currentWave = 1;
        private double waveTimer;

        private void Start()
        {
            CurrentValues.ClearEnemies();
            if (CurrentValues.FunnySettings)
            {
                wave = fwave;
            }
        }
            
            

        private void StartWaveTimer() => waveTimer = waveDelayTime;

        private void Update()
        {
            if (CurrentValues.EnemyCount <= 0 && waveTimer <= 0)
            {
                CurrentValues.ClearEnemies();
                StartWaveTimer();
            }
                
            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
                if (waveTimer <= 0)
                    SpawnWave();
            }
        }

        private void SpawnWave()
        {
            CurrentValues.MaxWave = Math.Max(currentWave, CurrentValues.MaxWave);
            var enemySpawnCount = UnityEngine.Random.Range(2 + currentWave / waveEnemyCountShift, 4 + currentWave / waveEnemyCountShift);
            var newWave = new List<EnemyScObject>();
            var positionCounter = 0;
            for (int i = 0; i < enemySpawnCount; i++)
            {
                var enemyId = UnityEngine.Random.Range(0, wave.Enemies.Count);
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