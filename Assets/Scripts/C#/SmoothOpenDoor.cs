using System.Collections;
using UnityEngine;

public class SmoothOpenDoor : MonoBehaviour
{
	//Make an empty game object and call it "Door"
	//Rename your 3D door model to "Body"
	//Parent a "Body" object to "Door"
	//Make sure thet a "Door" object is in left down corner of "Body" object. The place where a Door Hinge need be
	//Add a box collider to "Door" object and make it much bigger then the "Body" model, mark it trigger
	//Assign this script to a "Door" game object that have box collider with trigger enabled
	//Press "f" to open the door and "g" to close the door
	//Make sure the main character is tagged "player"
	
	public float smooth = 2.0f;
	public float openAngle = 90.0f;
	
	private bool open;
	private bool inSight;
	private Vector3 defaultRot;
	private Vector3 openRot;
	private Transform mTransform;
	private Transform cachedTransform { get { if (!mTransform) mTransform = transform; return mTransform; } }
	
	void OnEnable()
	{
		defaultRot = cachedTransform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y + openAngle, defaultRot.z);
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && inSight) {
			open = !open;
		}
		
		Vector3 target = open ? openRot : defaultRot;
		cachedTransform.eulerAngles = Vector3.Slerp(cachedTransform.eulerAngles, target, Time.deltaTime * smooth);
	}
	
	void OnGUI()
	{
		if (inSight) {
			GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			inSight = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			inSight = false;
		}
	}
}