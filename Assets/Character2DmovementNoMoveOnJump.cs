using UnityEngine;
using System.Collections;

public class Character2DmovementNoMoveOnJump : MonoBehaviour 
{
	public float speed = 2.0f;
	public float defaultSpeed = 2.0f;
	public float maxSpeed = 4.0f;
	public bool canJump = false;
	public float distanceFromGround = 1.0f;
	
	// Determines whether the character is grounded
	void Update() 
	{
		RaycastHit hit;
		Ray landingray = new Ray (transform.position, Vector3.down);
		Debug.DrawRay (transform.position, Vector3.down * distanceFromGround);

		if (canJump == false)
		{
			if(Physics.Raycast(landingray, out hit, distanceFromGround))
			{
				if(hit.collider.tag == "Terrain")
				{
					canJump = true;
					Debug.Log ("Ray has hit ground");
				}
			}
		}

		// Movement
		if (canJump == true)
		{
			if (Input.GetKey (KeyCode.UpArrow))
			{
				rigidbody.AddForce (0, 2, 5);
			}

			if (Input.GetKey (KeyCode.DownArrow))
			{
				rigidbody.AddForce (0, 2, -5);
			}

			if (Input.GetKey (KeyCode.RightArrow))
			{
				rigidbody.AddForce (5, 2, 0);
			}

			if (Input.GetKey (KeyCode.LeftArrow))
			{
				rigidbody.AddForce (-5, 2, 0);
			}

		}

		// Jump
		if (Input.GetKeyDown (KeyCode.Space) && canJump == true)
		{
			rigidbody.AddForce (0, 500, 0);	
			canJump = false;
		}

		// Stationary jump
		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.UpArrow))
		{
			rigidbody.AddForce (0, 0, 10);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.DownArrow))
		{
			rigidbody.AddForce (0, 0, -10);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.RightArrow))
		{
			rigidbody.AddForce (10, 0, 0);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.LeftArrow))
		{
			rigidbody.AddForce (-10, 0, 0);	
		}


		//Sprint
		if (Input.GetKey (KeyCode.LeftShift))
		{
			speed = maxSpeed;
		}

		if (!Input.GetKey (KeyCode.LeftShift))
		{
			speed = defaultSpeed;
		}
	}

	public void FixedUpdate() 
	{		
		rigidbody.velocity = new Vector3 
			(
			Mathf.Clamp(rigidbody.velocity.x, -speed, speed),
			Mathf.Clamp(rigidbody.velocity.y, -500, 5),
			Mathf.Clamp(rigidbody.velocity.z, -speed, speed)
			);
	}
}