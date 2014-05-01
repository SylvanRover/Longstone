using UnityEngine;
using System.Collections;

public class GateAnimation : MonoBehaviour
{
	public GateTrigger gate;

	private PlayerInventory playerInventory;
	private HashIDs hash;
	private GameObject player;
	private Animator anim;

	void Update ()
	{
		if (gate.gateTrigger)
		{
			anim.SetBool ("Open", true);
		}
	}
}