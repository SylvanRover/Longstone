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
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
			{
				rigidbody.AddForce (0, 0, 20);
				transform.eulerAngles = new Vector3(0, 180, 0);
			}

			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
			{
				rigidbody.AddForce (0, 0, -20);
				transform.eulerAngles = new Vector3(0, 0, 0);

			}

			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
			{
				rigidbody.AddForce (20, 0, 0);
				transform.eulerAngles = new Vector3(0, -90, 0);

			}

			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
			{
				rigidbody.AddForce (-20, 0, 0);
				transform.eulerAngles = new Vector3(0, 90, 0);
			}

			//Diagonal Movement Rotation
			if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) &&
				(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)))
			{
				transform.eulerAngles = new Vector3(0, 135, 0);
			}

			if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) &&
			    (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)))
			{
				transform.eulerAngles = new Vector3(0, -135, 0);
			}

			if ((Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) &&
			    (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)))
			{
				transform.eulerAngles = new Vector3(0, 45, 0);
			}

			if ((Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) &&
			    (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)))
			{
				transform.eulerAngles = new Vector3(0, -45, 0);
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
		    && (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)))
		{
			rigidbody.AddForce (0, 0, speed * 2);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)))
		{
			rigidbody.AddForce (0, 0, -speed * 2);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)))
		{
			rigidbody.AddForce (speed * 2, 0, 0);	
		}

		if (rigidbody.velocity.z < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)))
		{
			rigidbody.AddForce (-speed * 2, 0, 0);	
		}


		//Sprint
		if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && isGrounded)
		{
			speed = maxSpeed;
		}

		if (!(Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && isGrounded)
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
			Mathf.Clamp(rigidbody.velocity.y, -10, 5),
			Mathf.Clamp(rigidbody.velocity.z, -speed, speed)
			);
	}

	private void CheckRunTimePlatform()
	{
		float macFogStart = 0.0f;
		float macFogEnd = 2.0f;
		float winFogStart = 0.02f;
		float winFogEnd = 0.03f;
		switch(Application.platform)
		{
			case RuntimePlatform.OSXPlayer:
			case RuntimePlatform.OSXEditor:
			RenderSettings.fogStartDistance = macFogStart;
			RenderSettings.fogEndDistance = macFogEnd;
			break;
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.WindowsEditor:
			RenderSettings.fogStartDistance = winFogStart;
			RenderSettings.fogEndDistance = winFogEnd;
			break;
		default:
			print("error in SceneMaster.CheckRunTimePlatform");
			break;
		}
	}
}