using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    // pseudo singleton
    // have only the first instance of the manager be the one used, so it can be called multiple times and run once at that time
    private static EnemySpawnManager _instance; 
    
    public GameObject enemyPrefab; 
    bool canSpawn;
    public static EnemySpawnManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        canSpawn = true;
    }

    public void Spawn(Vector3 spawnPos)
    {
        if (!canSpawn)
            return;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        canSpawn = false;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
