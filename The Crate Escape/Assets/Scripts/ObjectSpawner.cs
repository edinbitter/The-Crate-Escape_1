
/*
 *  the purpose of this script is to instantiate randomly selected objects in such a way
 *   that they create a blockade that the player must get past to succeed
 *  
 *  may have to update the algorithm to checkfor special cases
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  algorithm one
*  
*  
*  the game will select a number of random obstacle objects from an algorithm
*  
*      the selection algorithm: 
*          the "row" of objects will start off completely filled with non-passable obstacles
*          
*          a random number of openings will be opened in the wall
*              the obenings can either be completely opened, or can be semi-opened (obstacles you can jump over)
*          
*          
*  the game will instantiate them
* 
*/

public class ObjectSpawner : MonoBehaviour
{
    //the set of prefabs available for spawning, null is used to represent an empty space
    [SerializeField]
    private Rigidbody[] obstaclePrefabs;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float spawnDelay = 10f;

    private Rigidbody[] obstacles;

    private int spawnCount;

    private int numOfOpenings = 0;

    

    void Start()
    {
        spawnCount = spawnPoints.Length;

        obstacles = new Rigidbody[spawnCount];

        StartCoroutine(SpawnEverySeconds(spawnDelay));
    }

    private void SelectObstacles()
    {
        //the "row" of objects will start off completely filled with non-passable obstacles
        for(int point = 0; point < spawnCount; point++)
        {
        
            obstacles[point] = obstaclePrefabs[0];
        }

        numOfOpenings = Random.Range(1, spawnCount - 1);

        //TODO make this random
        for(int point = 0; point < numOfOpenings; point++)
        {
            int randomNum = Random.Range(0, spawnCount);
            
            obstacles[randomNum] = null;
        }
    }

    //spawns the obstacles and resets the variables used
    private void SpawnObstacles()
    {
        for(int point = 0; point < spawnCount; point++)
        {
            if(obstacles[ point ] != null)
            {
                Instantiate(obstacles[point], spawnPoints[point].position, Quaternion.identity);
            }
        }
    }

    private IEnumerator SpawnEverySeconds( float seconds )
    {
        while(true)
        {
            SelectObstacles();

            SpawnObstacles();

            yield return new WaitForSecondsRealtime(seconds);
        }
    }

    /* method 2
     * 
     * 
    */
}


