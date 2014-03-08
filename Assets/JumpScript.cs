using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour 
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
}