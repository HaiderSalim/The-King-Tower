using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Header("Spawning parameters")]
    [SerializeField] private GameObject[] Paths;
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private GameObject[] Enemys;
    [SerializeField] private int WaveEnemyAmount = 5;
    private Wave_Manager wave;

    private void Start()
    {
        wave = GetComponent<Wave_Manager>();
    }

    private void Update()
    {
        if (wave.WaveNumber <= 1 && !wave.isSpawned)
        {
            WaveEnemyAmount = 5;
            SpawnWave1(WaveEnemyAmount);
            wave.isSpawned = true;
            wave.isWaveend = true;
        }
        if (wave.WaveNumber == 2 && !wave.isSpawned)
        {
            WaveEnemyAmount = 10;
            SpawnWave2(WaveEnemyAmount);
            wave.isSpawned = true;
            wave.isWaveend = true;
        }
        if (wave.WaveNumber == 3 && !wave.isSpawned)
        {
            WaveEnemyAmount = 20;
            SpawnWave3(WaveEnemyAmount);
            wave.isSpawned = true;
            wave.isWaveend = true;
        }
        if (wave.WaveNumber == 4 && !wave.isSpawned)
        {
            WaveEnemyAmount = 30;
            SpawnWave4(WaveEnemyAmount);
            wave.isSpawned = true;
            wave.isWaveend = true;
        }
        if (wave.WaveNumber == 5 && !wave.isSpawned)
        {
            WaveEnemyAmount = 25;
            SpawnWave5(WaveEnemyAmount);
            wave.isSpawned = true;
            wave.isWaveend = true;
        }
    }

    private void SpawnWave1(int amount)
    {
        int spawnnum = Random.Range(0, SpawnPoints.Length);
        int multiplayer = 0;
        Transform spawn = SpawnPoints[spawnnum];

        if (spawnnum <= (SpawnPoints.Length -1) / 2)
        {
            multiplayer = 1;
        }
        else if (spawnnum > (SpawnPoints.Length - 1) / 2)
        {
            multiplayer = -1;
        }

        float offset = 0;
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(Enemys[0],
                new Vector3(SpawnPoints[spawnnum].position.x + offset * multiplayer, SpawnPoints[spawnnum].position.y, SpawnPoints[spawnnum].position.z) ,
                Quaternion.identity);

            offset += 0.16f;

            obj.GetComponent<WayPoinFollowSystem>().WaypointPath = Paths[spawnnum];
        }
    }

    private void SpawnWave2(int amount)
    {
        Transform spawn;
        int multiplayer = 0;
        float offset = 0;
        for (int i = 0; i < amount; i++)
        {
            int spawnnum = Random.Range(0, SpawnPoints.Length);
            spawn = SpawnPoints[spawnnum];
            if (spawnnum <= (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = 1;
            }
            else if (spawnnum > (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = -1;
            }

            GameObject obj = Instantiate(Enemys[0],
                new Vector3(SpawnPoints[spawnnum].position.x + offset * multiplayer, SpawnPoints[spawnnum].position.y, SpawnPoints[spawnnum].position.z),
                Quaternion.identity);

            offset += 0.16f;

            obj.GetComponent<WayPoinFollowSystem>().WaypointPath = Paths[spawnnum];
        }
    }

    private void SpawnWave3(int amount)
    {
        Transform spawn;
        int multiplayer = 0;
        float offset = 0;
        for (int i = 0; i < amount; i++)
        {
            int spawnnum = Random.Range(0, SpawnPoints.Length);
            spawn = SpawnPoints[spawnnum];
            if (spawnnum <= (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = 1;
            }
            else if (spawnnum > (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = -1;
            }

            GameObject obj = Instantiate(Enemys[0],
                new Vector3(SpawnPoints[spawnnum].position.x + offset * multiplayer, SpawnPoints[spawnnum].position.y, SpawnPoints[spawnnum].position.z),
                Quaternion.identity);

            offset += 0.16f;

            obj.GetComponent<WayPoinFollowSystem>().WaypointPath = Paths[spawnnum];
        }
    }

    private void SpawnWave4(int amount)
    {
        Transform spawn;
        int multiplayer = 0;
        float offset = 0;
        for (int i = 0; i < amount; i++)
        {
            int spawnnum = Random.Range(0, SpawnPoints.Length);
            spawn = SpawnPoints[spawnnum];
            if (spawnnum <= (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = 1;
            }
            else if (spawnnum > (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = -1;
            }

            GameObject obj = Instantiate(Enemys[0],
                new Vector3(SpawnPoints[spawnnum].position.x + offset * multiplayer, SpawnPoints[spawnnum].position.y, SpawnPoints[spawnnum].position.z),
                Quaternion.identity);

            offset += 0.16f;

            obj.GetComponent<WayPoinFollowSystem>().WaypointPath = Paths[spawnnum];
        }
    }


    private void SpawnWave5(int amount)
    {
        Transform spawn;
        int multiplayer = 0;
        float offset = 0;
        for (int i = 0; i < amount; i++)
        {
            int spawnnum = Random.Range(0, SpawnPoints.Length);
            spawn = SpawnPoints[spawnnum];
            if (spawnnum <= (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = 1;
            }
            else if (spawnnum > (SpawnPoints.Length - 1) / 2)
            {
                multiplayer = -1;
            }

            GameObject obj = Instantiate(Enemys[0],
                new Vector3(SpawnPoints[spawnnum].position.x + offset * multiplayer, SpawnPoints[spawnnum].position.y, SpawnPoints[spawnnum].position.z),
                Quaternion.identity);

            offset += 0.16f;

            obj.GetComponent<WayPoinFollowSystem>().WaypointPath = Paths[spawnnum];
        }
    }
}
