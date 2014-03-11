using UnityEngine;
using System.Collections;

public class CameraFollowCharacterBehavior : MonoBehaviour 
{

	public GameObject _Player;
	public float cameraY = 2f;
	public float cameraZ = -10f;
	public Character3DmovementNoMoveOnJump _isGrounded;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	void Update () 
	{
		Debug.Log ("this is working");
		this.transform.position = new Vector3 (_Player.transform.position.x, this.transform.position.y, _Player.transform.position.z + cameraZ);
		if (_isGrounded.isGrounded) 
		{
			this.transform.position = new Vector3 (this.transform.position.x, _Player.transform.position.y + cameraY, this.transform.position.z);
		}
	}
}
