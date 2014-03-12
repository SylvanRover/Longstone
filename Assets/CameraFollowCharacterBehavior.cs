using UnityEngine;
using System.Collections;

public class CameraFollowCharacterBehavior : MonoBehaviour 
{

	public GameObject _Player;
	public float cameraY = 2f;
	public float cameraZ = -10f;
	public Character3DmovementNoMoveOnJump _isGrounded;
	public float cameraTweenTime = 1.0f;
	public float cameraSpeed = 0.01F;
	private float startTime;
	private float journeyLength;
	
	// Use this for initialization
	void Start () 
	{
		startTime = Time.deltaTime;
		journeyLength = Vector3.Distance(this.transform.position, new Vector3 (this.transform.position.x, _Player.transform.position.y + cameraY));
	}
	
	void Update () 
	{
		this.transform.position = new Vector3 (_Player.transform.position.x, this.transform.position.y, _Player.transform.position.z + cameraZ);
		if (_isGrounded.isGrounded) 
		{
			float distCovered = (Time.time - startTime) * cameraSpeed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (this.transform.position, new Vector3 (this.transform.position.x, _Player.transform.position.y + cameraY, this.transform.position.z), fracJourney);
		}
	}
}
