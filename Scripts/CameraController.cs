using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float easeFactor;

	private Vector3 offset;
	private float mouseX;
	private float mouseY;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;

	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
		HandleRotation ();
		mouseX = Input.mousePosition.x;
	}

	void HandleRotation(){
		if (Input.mousePosition.x != mouseX) {
			var cameraRotationY = (Input.mousePosition.x - mouseX) * easeFactor * Time.deltaTime;
			this.transform.Rotate (0, cameraRotationY, 0);
		}
	}
}
