using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {

	public Image menuBox;
	public Text about;
	public Text aboutEisah;
	public Text aboutAbigail;
	public Text aboutCaleb;
	public Text HowTo;
	public float fadeSpeed = 1.5f;
	public Image guiTextures;

	private bool end = false;
	private bool startScene = true;

	public void Start(){
		FadeToClear ();
		HowTo.enabled = false;
		menuBox.enabled = false;
		about.enabled = false;
		aboutEisah.enabled = false;
		aboutAbigail.enabled = false;
		aboutCaleb.enabled = false;
	}

	void Update(){
		FadeToClear ();
		if (end == true) {
			FadeToBlack ();
		}
	}

	public void pley(){
		end = true;
		FadeToBlack ();
	}

	public void howTo(){
		menuBox.enabled = true;
		HowTo.enabled = true;
		about.enabled = false;
		aboutEisah.enabled = false;
		aboutAbigail.enabled = false;
		aboutCaleb.enabled = false;
	}

	public void About(){
		HowTo.enabled = false;
		menuBox.enabled = true;
		about.enabled = true;
		aboutEisah.enabled = true;
		aboutAbigail.enabled = true;
		aboutCaleb.enabled = true;
	}

	public void Quit(){
		HowTo.enabled = false;
		menuBox.enabled = false;
		about.enabled = false;
		aboutEisah.enabled = false;
		aboutAbigail.enabled = false;
		aboutCaleb.enabled = false;
		Application.Quit ();
	}

	void FadeToClear ()
	{
		if (startScene == true) {
			// Lerp the colour of the texture between itself and transparent.
			guiTextures.color = Color.Lerp (guiTextures.color, Color.clear, fadeSpeed * Time.deltaTime);

			if (guiTextures.color.a <= 0.05f) {
				// ... set the colour to clear and disable the GUITexture.
				guiTextures.color = Color.clear;
				guiTextures.enabled = false;

				// The scene is no longer starting.
				startScene = false;
			}
		}
	}


	void FadeToBlack (){
		
		guiTextures.enabled = true;

		guiTextures.color = Color.Lerp(guiTextures.color, Color.black, fadeSpeed * Time.deltaTime);

		if(guiTextures.color.a >= 0.95f)
			// ... reload the level.
			Cursor.lockState = CursorLockMode.Locked;
			SceneManager.LoadScene("House");
	}
}
