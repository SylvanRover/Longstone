using UnityEngine;
using System.Collections;

public class Character2Dmovement : MonoBehaviour 
{
	public float speed = 1.0f;
	public bool canJump = true;
	
	void Start()		
	{	

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
		}
		
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.right * Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.position += transform.up * Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space) && canJump == true)
		{
			rigidbody.AddForce (0, 225, 0);	
			canJump = false;
		}
	}
}