using UnityEngine;
using System.Collections;

public class Character3DmovementNoMoveOnJump : MonoBehaviour 
{
	public float speed = 2.0f;
	public float defaultSpeed = 2.0f;
	public float maxSpeed = 4.0f;
	public bool isGrounded = false;
	public float distanceFromGround = 0.5f;
	
	// Determines whether the character is grounded
	void Update() 
	{
		// Movement
		if (isGrounded)
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
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded)
		{
			rigidbody.AddForce (0, 500, 0);	
			isGrounded = false;
		}

		// Stationary jump
		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.UpArrow))
		{
			rigidbody.AddForce (0, 0, speed * 2);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.DownArrow))
		{
			rigidbody.AddForce (0, 0, -speed * 2);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.RightArrow))
		{
			rigidbody.AddForce (speed * 2, 0, 0);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.LeftArrow))
		{
			rigidbody.AddForce (-speed * 2, 0, 0);	
		}


		//Sprint
		if (Input.GetKey (KeyCode.LeftShift) && isGrounded)
		{
			speed = maxSpeed;
		}

		if (!Input.GetKey (KeyCode.LeftShift) && isGrounded)
		{
			speed = defaultSpeed;
		}
	}

	public void FixedUpdate() 
	{
		// Ground detection
		/*RaycastHit hit;
		Ray landingray = new Ray (transform.position, Vector3.down);
		Debug.DrawRay (transform.position, Vector3.down * distanceFromGround);
		
		if (!isGrounded)
		{
			if(Physics.Raycast(landingray, out hit, distanceFromGround))
			{
				if(hit.collider.tag == "Terrain")
				{
					isGrounded = true;
					Debug.Log ("Ray has hit ground");
				}
			}
		}
		
		if (rigidbody.velocity.y > 0.25f)
		{
			isGrounded = false;
			Debug.Log ("is moving on the y axis");
		}*/

		rigidbody.velocity = new Vector3 
			(
			Mathf.Clamp(rigidbody.velocity.x, -speed, speed),
			Mathf.Clamp(rigidbody.velocity.y, -500, 5),
			Mathf.Clamp(rigidbody.velocity.z, -speed, speed)
			);
	}
}