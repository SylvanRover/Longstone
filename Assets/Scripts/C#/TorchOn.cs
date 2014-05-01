using UnityEngine;
using System.Collections;

public class TorchOn : MonoBehaviour
{

	public bool requireKey; 

	private PlayerInventory playerInventory;
	private HashIDs hash;
	private GameObject player;
	private Animator anim;

	void Awake ()
	{
		anim = gameObject.GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
		playerInventory = player.GetComponent<PlayerInventory>();
	}

	void Update () 
	{
		if (playerInventory.hasKey)
		{
			Debug.Log ("Bool Set");
			anim.SetBool ("On", true);
		}
		if (!playerInventory.hasKey)
		{
			Debug.Log ("Bool Set");
			anim.SetBool ("On", false);
		}
	}
}
