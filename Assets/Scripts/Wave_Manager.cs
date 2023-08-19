using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    [Header("Waves Info")]
    public int WaveNumber = 1;
    public bool isSpawned = false;
    public bool isWaveend = false;
    public GameObject[] Enemys = null;

    private void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("enemy");
        if( Enemys.Length == 0 && isWaveend)
        {
            isSpawned = false;
            isWaveend = false;
            WaveNumber++;
        }
    }
}
