using UnityEngine;
using System.Collections;

public class CameraFollowCharacterBehavior : MonoBehaviour 
{

	public GameObject _Player;
	public float cameraY = 2f;
	public float cameraZ = -10f;
	public Character3DmovementNoMoveOnJump _isGrounded;
	public float cameraTweenTime = 1.0f;
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public Transform target;
	public float smooth = 5.0F;
	
	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	/*IEnumerator TransisitonCamera ()
	{
		if (_isGrounded.isGrounded) 
		{
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3 (this.transform.position.x, _Player.transform.position.y + cameraY, this.transform.position.z), cameraTweenTime * Time.deltaTime);
			yield return null;
		}
	}*/
	
	void Update () 
	{
		this.transform.position = new Vector3 (_Player.transform.position.x, this.transform.position.y, _Player.transform.position.z + cameraZ);
		if (_isGrounded.isGrounded) 
		{
			//StartCoroutine (TransisitonCamera ());
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (this.transform.position, new Vector3 (this.transform.position.x, _Player.transform.position.y + cameraY, this.transform.position.z), fracJourney);
		}
	}
}
