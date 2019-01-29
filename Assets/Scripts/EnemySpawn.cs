using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // ***this script is the Spawn point for enemies, place in empty game object to spawn a game object randomly
    // script periodicaly spawns an enemy entity relative to player location 
    // and if the player is "on a quest"


    //public GameObject enemy;  //enemy prefab
    GameObject player;  // the PROTAGONIST
    Coroutine SpawnRoutine;

    bool isSpawning;  // when to spawn enemy

    float distance; //current distance between the player and enemy
    float wait = 2f; 
    public static int minDistance = 1; 
    public static int maxDistance = 30;
    
    //float angle = Random.Range(-Mathf.PI, Mathf.PI);
    Vector2 spawnPos; // location where enemy will spawn. like from hell 
    

    // Start is called before the first frame update
    void Start()
    {
        float offset = Random.Range(minDistance, maxDistance);

        player = GameObject.FindGameObjectWithTag("player");  //tracks the player object
        spawnPos = player.transform.position; 
        Vector2 spot = Random.insideUnitCircle.normalized * offset;
        if (spot == Vector2.zero)
        {
            spawnPos = Vector2.left;
        }
        
        spawnPos.x += spot.x;
        spawnPos.y += spot.y;

        isSpawning = true;
        TriggerSpawn(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public IEnumerator spawnEnemy()
    {
        // spawn the enemy when the player is on a quest

        EnemySpawnManager.Instance.Spawn(spawnPos);
        isSpawning = false;
        yield return new WaitForSeconds(wait);

    }

    public static int spawnCount = 0;

    public void TriggerSpawn()
    {
        if (SpawnRoutine == null)
        {
            EnemySpawn.spawnCount++;
            Debug.Log("Spawning enemy " + EnemySpawn.spawnCount);
            SpawnRoutine = StartCoroutine(spawnEnemy());  // spawn the creature
        }
        else
        {
            StopCoroutine(SpawnRoutine); 
        }
    }

  

}

