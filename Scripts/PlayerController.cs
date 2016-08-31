using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;

	private bool contact;
	private float y;

	void Start(){

	}

	void FixedUpdate(){

		if (Input.GetKey (KeyCode.W) | Input.GetKey (KeyCode.UpArrow)) {
			moveForward (speed);
		}

		if (Input.GetKey (KeyCode.S) | Input.GetKey (KeyCode.DownArrow)) {
			moveBack (speed);
		}

		if (Input.GetKey (KeyCode.A) | Input.GetKey (KeyCode.LeftArrow)) {
			moveLeft (speed);
		}

		if (Input.GetKey (KeyCode.D) | Input.GetKey (KeyCode.RightArrow)) {
			moveRight (speed);
		}
	}

	private void moveForward(float speed) {
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}

	private void moveBack(float speed) {
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}

	private void moveRight(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}

	private void moveLeft(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}
		
}
