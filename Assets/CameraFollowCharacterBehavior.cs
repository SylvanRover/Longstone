using UnityEngine;
using System.Collections;

public class CameraFollowCharacterBehavior : MonoBehaviour 
{

	public GameObject _Player;
	public float cameraY = 2f;
	public float cameraZ = -10f;
	public Character3DmovementNoMoveOnJump _isGrounded;
	public float cameraTweenTime = 1.0f;

	// Use this for initialization
	void Start () 
	{
	
	}

	IEnumerator TransisitonCamera ()
	{
		if (_isGrounded.isGrounded && _Player.rigidbody.velocity.y > 0) 
		{
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3 (this.transform.position.x, _Player.transform.position.y + cameraY, this.transform.position.z), cameraTweenTime * Time.deltaTime);
			yield return null;
		}
	}
	
	void Update () 
	{
		this.transform.position = new Vector3 (_Player.transform.position.x, this.transform.position.y, _Player.transform.position.z + cameraZ);
		StartCoroutine (TransisitonCamera ());
	}
}
