using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Enemy;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveScript> waves;
    [SerializeField] private List<Vector3> positions;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Player.PlayerScript player;
    [SerializeField] private double waveDelayTime;

    private int currentEnemiesCount = 0;
    private int currentWave = 0;
    private double waveTimer = 0;

    private void Start()
    {
        SpawnWave();
    }

    private void Update()
    {
        if (waveTimer > 0) 
        { 
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                SpawnWave();
            }
        }
    }

    private void StartWaveTimer()
    {
        waveTimer = waveDelayTime;
    }

    private void SpawnWave()
    {
        if (currentWave >= waves.Count)
            return;
        var positonCounter = 0;
        foreach (var enemyScObject in waves[currentWave].Enemies)
        {
            var enemyInstance = Instantiate(enemyPrefab, positions[positonCounter], new Quaternion());
            var enemyScript = enemyInstance.GetComponent<EnemyScript>();
            enemyScript.SetScObject(enemyScObject);
            enemyScript.Target = player;
            currentEnemiesCount++;
            positonCounter++;
            if (positonCounter >= positions.Count)
            {
                positonCounter = 0;
            }
        }
        currentWave++;
        StartWaveTimer();
    }
}
