using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour 
{
	public float speed = 2.0f;
	public float defaultSpeed = 2.0f;
	public float maxSpeed = 4.0f;
	public bool isGrounded2 = false;
	public float distanceFromGround = 0.5f;
	
	// Determines whether the character is grounded
	void Update() 
	{
		// Movement
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
		{
			rigidbody.AddForce (0, 0, 30);
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
		{
			rigidbody.AddForce (0, 0, -30);
			transform.eulerAngles = new Vector3(0, 0, 0);
			
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
		{
			rigidbody.AddForce (30, 0, 0);
			transform.eulerAngles = new Vector3(0, -90, 0);
			
		}
		
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
		{
			rigidbody.AddForce (-30, 0, 0);
			transform.eulerAngles = new Vector3(0, 90, 0);
		}
		
		//Diagonal Movement Rotation
		if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) &&
		    (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)))
		{
			transform.eulerAngles = new Vector3(0, 135, 0);
			rigidbody.AddForce (15f, 0, -15f);
		}
		
		if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) &&
		    (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)))
		{
			transform.eulerAngles = new Vector3(0, -135, 0);
			rigidbody.AddForce (-15f, 0, -15f);
		}
		
		if ((Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) &&
		    (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)))
		{
			transform.eulerAngles = new Vector3(0, 45, 0);
			rigidbody.AddForce (15f, 0, 15f);
		}
		
		if ((Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) &&
		    (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)))
		{
			transform.eulerAngles = new Vector3(0, -45, 0);
			rigidbody.AddForce (-15f, 0, 15f);
		}
		
		// Jump
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded2)
		{
			rigidbody.AddForce (0, 500, 0);	
			isGrounded2 = false;
		}
		
		//Sprint
		if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && isGrounded2)
		{
			speed = maxSpeed;
		}
		
		if (!(Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && isGrounded2)
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