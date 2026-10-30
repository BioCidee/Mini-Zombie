using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    [Header("---- Zombie Prefab")]
    [SerializeField] private Transform zombieList;
    [SerializeField] private GameObject zombie;

    [Header("---- Spawn Parameters ----")]
    [SerializeField] private int numberToSpawn;
    [SerializeField] private int currentZombie = 0;
    [SerializeField] private bool zombieCanSpawn = false;

    [Header("---- Wave ----")]
    [SerializeField] private int numberWave;
    [SerializeField] private float timerSpawn = 2f;
    private float currentTimer;

    [Header("---- SpawnPoint")]
    [SerializeField] private List<Transform> spawnList = new List<Transform>();

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        ZombieSpawnSystem();
    }

    public void StartWave()
    {
        numberWave = 1;
        numberToSpawn = numberWave * 2;
        zombieCanSpawn = true;
    }

    public void ZombieSpawnSystem() {
        if (zombieCanSpawn)
        {
            if(currentTimer <= 0)
            {
                currentTimer = timerSpawn;
                SpawnZombie();
            }
            else
            {
                currentTimer -= Time.deltaTime;
            }
        }
    }

    private void SpawnZombie() {
        if (zombieCanSpawn && numberToSpawn > 0) {
            Transform spawnPoint = spawnList[Random.Range(0, spawnList.Count)];
            GameObject newZombie = Instantiate(zombie, zombieList);
            newZombie.transform.position = spawnPoint.position;

            numberToSpawn--;
        }
        else
        {
            numberToSpawn = 0;
            Debug.Log("Spawn Wave End");
        }
    }
}
