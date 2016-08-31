using UnityEngine;
using System.Collections;

public class InteractTV : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject screen;
	public GameObject o;

	private bool toggle;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		toggle = false;
		screen.SetActive(toggle);
		audio = GetComponent<AudioSource>();
		audio.mute = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 5.0f)) {
				Collider l = hit.collider;
				if (l == o.GetComponent<Collider>()) {
					if (toggle == false) {
						toggle = true;
						audio.mute = false;
						screen.SetActive(toggle);
					}
					else{
						toggle = false;
						audio.mute = true;
						screen.SetActive(toggle);
					}
				}
			}
		}
	}

	public void Switch(){
		if (toggle == false) {
			toggle = true;
			screen.SetActive (toggle);
			ObjectLists.AddItem (o);
			audio.mute = false;
		}
	}
}
