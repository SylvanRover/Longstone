using UnityEngine;
using System.Collections;

public class JumpScriptAdv : MonoBehaviour 
{
	public bool canJump = true;
	
	void Update()		
	{		
		if (Input.GetKeyDown (KeyCode.Space) && canJump == true)
		{
			rigidbody.AddForce (0, 225, 0);	
			canJump = false;
		}
	}

	void OnCollisionEnter(Collision collision) 
	{
		foreach (ContactPoint contact in collision.contacts) 
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}

		if (collision.relativeVelocity.magnitude > 0) 
		{
			canJump = true;
			Debug.Log("Player is colliding");
		}
		
	}
}