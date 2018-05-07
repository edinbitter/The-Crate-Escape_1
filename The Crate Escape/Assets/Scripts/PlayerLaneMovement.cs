/*
 * PlayerLaneMovement
 * 
 * the purpose of this script is to create one dimensional "lane" based movement: the target object will move between incremented points in space
 *  and a upper and lower bounds on the positions to where the player is bounded by a set of positions.
 *  
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class will provide a means to have the player block move in a lane system, with upper and lower bounds
public class PlayerLaneMovement : MonoBehaviour
{
    public Rigidbody player;

    //how fast the player moves between positions
    public float speed = 50f;
    //the "borders" of the map, used to set limits on how far you can move
    public float bounds = 5f;
    //the distance between positions
    public float spacing = 5f;
    //the target set when moving to a new point
    private float targetPosition;
    //used to determine which way to move
    private float direction;
    //bool used to control state of movement function
    private bool isMoving = false;
    //this variable is used to make the input fire only once
    private bool axisDown = false;
    
    public void Start()
    {
        
        targetPosition = player.position.x;
    }

    public void FixedUpdate()
    {
        Debug.Log(Random.Range(0, 3));

        //a boolean determines is movmement occurs
        if (!isMoving)
        {
            //the script will get axis movement
            float input = Input.GetAxisRaw("Horizontal");
           
            if (input != 0f && !axisDown)
            {
                axisDown = true;
                isMoving = true;

                //if the player will not move out of bounds, then the boolean will be set to skip over the input section
                //if it will move out of bounds then target bounds will be set to bounds

                targetPosition = player.position.x + (input * spacing);
                
                direction = Mathf.Sign(targetPosition - player.position.x);
                
                
                //if targetPosition is greater than the boundary in either direction then it is set to bounds
                if(targetPosition > 0 && targetPosition > bounds)
                {
                    targetPosition = bounds;
                }
                else if(targetPosition < 0 && targetPosition < -bounds)
                {
                    targetPosition = -bounds;
                }
            }

           
            
        }
        else
        {
            
            player.MovePosition(new Vector3(speed * direction * Time.deltaTime, 0, 0) + player.position);

            if((player.position.x > targetPosition - 0.1f) && (player.position.x < targetPosition + 0.1f))
            {
                isMoving = false;

                player.position = new Vector3(targetPosition, player.position.y, player.position.z);
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0f && axisDown != false)
        {
            axisDown = false;
        }
    }




}
