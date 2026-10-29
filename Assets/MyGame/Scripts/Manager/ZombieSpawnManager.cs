using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    [Header("---- Zombie Prefab")]
    [SerializeField] private GameObject zombie;

    [Header("---- Spawn Parameters ----")]
    [SerializeField] private int numberToSpawn;
    [SerializeField] private int currentZombie = 0;
    [SerializeField] private bool zombieCanSpawn = false;

    [Header("---- SpawnPoint")]
    [SerializeField] private List<Transform> spawnList = new List<Transform>(); 

    public void SetSpawnZombieOn() {

    }

    private void SpawnZombie() {
        
    }

    private void GetRamdomSpawnPoint() {
        
    }
}
