//LightSwitch Script
//IMPORTANT: PLEASE READ
//......................
// IN ORDER FOR THIS SCRIPT
// TO RUN, YOU MUST ADD A
// BOX COLLIDER TO YOUR 
//LIGHTSWITCH!
//.......................
//THIS SCRIPT IS TRIGGERED
//BY CLICKING THE LIGHTSWITCH
//BOX COLLIDER
//......................


using UnityEngine;
using System.Collections;

	// If you change the name of your script, change the public
	// class below from LightSwitch to what you named the script.
public class LightSwitch : MonoBehaviour {

	// Declares the light game object as "DragYourLightHere".
	// Do not try to drag your light from unity into the actual script.
	// It is named like this so that the Unity editor will display where to
	// drag your light.
	public Light DragYourLightHere;
	public GameObject mainCamera;
	public GameObject lSwitch;

	// Declares the two states for the lightswitch: on or off.
	private enum State {
		on,
		off
	}

	// Declares the State as state.
	private State state;
	private AudioSource audio;

	// Initializes the lightswitch so that the script knows the lights are on to
	// start with.
	void Start () {
		audio = GetComponent<AudioSource>();
		if (state == LightSwitch.State.on)
			TurnOff ();
		else
			TurnOn ();
	}

	// On the mouse up event, the state changes to off if it was on before clicked, and
	// the state changes to on if it was off before clicked.
//	public void OnMouseUp() {
//		if (state == LightSwitch.State.on)
//						TurnOff ();
//				else
//						TurnOn ();
//	}

	public void Update(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 5.0f)) {
				Collider l = hit.collider;
				if (l == lSwitch.GetComponent<Collider>()) {
					if (state == LightSwitch.State.on)
						TurnOff ();
					else
						TurnOn ();
				}
			}
		}
	}

	public void Switch(){
		if (state == LightSwitch.State.off)
			TurnOn ();
	}

	// Turn on subprocedure: plays the TurnOn Animation, sets the state to on, and enables
	// the light.
	private void TurnOn() {
		audio.Play ();
		GetComponent<Animation>().Play ("TurnOnAnimation");
		state = LightSwitch.State.on;
		DragYourLightHere.enabled = true;
		ObjectLists.AddItem (lSwitch);

}

	//Turn off subprocedure: plays the TurnOff Animation, sets the state to off, and
	// disables the light.
	private void TurnOff() {
		audio.Play ();
		GetComponent<Animation>().Play ("TurnOffAnimation");
		state = LightSwitch.State.off;
		DragYourLightHere.enabled = false;
		ObjectLists.RemoveItem (lSwitch);
	}
}

