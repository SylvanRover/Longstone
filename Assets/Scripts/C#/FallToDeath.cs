using UnityEngine;
using System.Collections;

public class FallToDeath : MonoBehaviour 
{
	
	public Character3DmovementNoMoveOnJump _Character;
	
	void OnTriggerEnter (Collider FallToDeath) 
	{
		if (FallToDeath.gameObject.tag == "FallToDeath") 
		{
			Debug.Log ("Fell to your death");
			Application.LoadLevel ("Game");
		}
	}
}