using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    GameObject player;  // the PROTAGONIST
    EnemySpawn enemy;

    public float speed = 5f; // how fast the enemy moves 
    public bool ishunting;  // check if the enemy is actively hunting player
    

    float distance; //current distance between the player and enemy
    float attackTime;  //for how long the monster will attack the player

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");  //tracks the player object
        ishunting = false;
        Debug.Log(ishunting);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(gameObject.transform.position, player.transform.position); // find distance between enemy and player

        if (ishunting)
        {
            Hunt(); // begin the hunt 
        }
    }

    void Hunt()
    {
        //move the enemy towards the player 

        transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;  // move the enemy 

        if (distance > EnemySpawn.maxDistance)
        {
            // chase player based on distance, attack if close enough
            //transform.LookAt(player.transform);
           //transform.position += transform.forward * speed * Time.deltaTime;  // move the enemy 
            //Debug.Log();

        }

        if (distance <= EnemySpawn.minDistance)
        {
            // attack player and leave if it isn't dead
            Debug.Log("nom nom");

        }

        //ishunting = false; //stop hunting once done
    }

    public void IsHunting( bool hunt)
    {
        ishunting = hunt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
