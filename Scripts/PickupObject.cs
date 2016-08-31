using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

	public GameObject mainCamera;
	public float distance;
	public float smooth;

	private GameObject carriedObject;
	private bool carrying;

	void Start(){

	}

	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry (carriedObject);
			checkDrop ();
		} else {
			pickUp ();
		}
	}

	void carry(GameObject other){
		other.transform.position = Vector3.Lerp (other.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		//other.transform.rotation = Quaternion.identity;
	}

	void pickUp(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 5.0f)) {
				PickupObject p = hit.collider.GetComponent<PickupObject> ();
				if (p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody> ().useGravity = false;
				}
			}
		}
	}

	void checkDrop(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			dropObject ();
		}
	}

	void dropObject(){
		carrying = false;
		carriedObject.GetComponent<Rigidbody> ().useGravity = true;
		carriedObject = null;
	}
}
