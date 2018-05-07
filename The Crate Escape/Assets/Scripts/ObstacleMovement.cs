/*
 * this script handles the movement of the obstacle object
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private Vector3 velocity = new Vector3(0, 0, -500);

    public float Speed
    {
        get
        {
            return velocity.z;
        }
        
        set
        {
            velocity.z = value;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rigid.AddForce(velocity * Time.fixedDeltaTime);

        //TODO put this in a separate script
        //destroys object once it is out of player sight
        if(rigid.position.z <= -10)
        {
            Destroy(gameObject);
        }
	}
}
