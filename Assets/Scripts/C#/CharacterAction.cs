using UnityEngine;
using System.Collections;

public class CharacterAction : MonoBehaviour {

	public bool actionActived = false;
	public bool actionCollider = false;

	void OnTriggerStay (Collider other) 
	{
		actionCollider = true;
		Debug.Log ("Action possible");
	}
	
	void OnTriggerExit (Collider other)
	{
		actionCollider = false;
		Debug.Log ("Action not possible");
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.E) && actionCollider == true)
		{
			actionActived = true;
			Debug.Log ("Action activated");
		}
		if (!Input.GetKey (KeyCode.E))
		{
			actionActived = false;
			Debug.Log ("Action not activated");
		}
	}
}
