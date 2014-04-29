using UnityEngine;
using System.Collections;

public class PlayerIsGrounded : MonoBehaviour 
{

	public Character3DmovementNoMoveOnJump _isGrounded;

	void OnTriggerStay (Collider other) 
	{
		_isGrounded.isGrounded = true;
		Debug.Log ("Player is grounded");
	}

	void OnTriggerExit (Collider other)
	{
		_isGrounded.isGrounded = false;
		Debug.Log ("Player is not grounded");
	}
}