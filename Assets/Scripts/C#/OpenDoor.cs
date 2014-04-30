using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public CharacterAction _isActivated;
	public bool open = false;
		
	private Animator anim;                      // Reference to the animator component.
	private HashIDs hash;                       // Reference to the HashIDs script.
	private GameObject player;

	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
	}
}
