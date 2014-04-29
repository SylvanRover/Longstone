using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public CharacterAction _isActivated;
	public bool open = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_isActivated.actionActived)
			open = true;
			Debug.Log ("Door Opened");
	}
}
