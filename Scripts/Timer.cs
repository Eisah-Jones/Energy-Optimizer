using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public Text timerText;
	public float minutes;
	public float seconds;
	public float second;
	public float score;
	public float max_health;
	public float cur_health;
	public Image energy;
	public float calc_health;
	public float fadeSpeed = 1.5f;
	public Image guiTextures;

	private bool end = false;
	private bool startScene = true;
	private int itemsOn;
	private int energyUsed = 0;
	private int savedEnergy = 0;

	// Use this for initialization
	void Start () {
		end = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		timerText.text = "3:00";
		minutes = 2.0f;
		second = 64.0f;
		calc_health = 100;
		InvokeRepeating ("decreaseEnergy", 5.0f, 1f);
		InvokeRepeating ("calcHealth", 5.0f, 1f);
		InvokeRepeating ("calcUsedEnergy", 5.0f, 8f);
	}
	
	// Update is called once per frame
	void Update () {
		FadeToClear ();
		seconds = Mathf.Round(second) - Mathf.Round(Time.timeSinceLevelLoad);
		if (seconds < 0 && minutes != 0.0f) {
			second += 60;
			minutes -= 1;
		}

		if (seconds > 59) {
			end = false;
			timerText.text = "3:00";
		} else {
			if (seconds != -1){
				if (seconds <= 0 && minutes <= 0) {
					timerText.text = "0:00";
				} else {
					if (seconds >= 0.0f && seconds <= 9.0f) {
						timerText.text = minutes.ToString () + ":0" + seconds.ToString ();
					} else {
						timerText.text = minutes.ToString () + ":" + seconds.ToString ();
					}
				}
			}
		}

		if (seconds == 0 && minutes == 0) {
			EndInfo.setWin ("win");
			end = true;
		} else if (calc_health <= 0) {
			EndInfo.setWin ("lose");
			end = true;
		}

		if (end == true) {
			EndInfo.setEnergy (energyUsed, savedEnergy);
			FadeToBlack ();
		}
		
	}

	void FixedUpdate(){
		decreaseEnergy ();
	}

	void calcHealth(){
		itemsOn = 0;
		foreach(GameObject appliance in ObjectLists.on){
			if (appliance.tag == "TV") {
				itemsOn += 3;
			} else {
				itemsOn += 1;
			}
		}

		cur_health -= itemsOn;
		calc_health = cur_health / max_health;
	}

	void decreaseEnergy(){
		energy.fillAmount = calc_health;
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

		guiTextures.color = Color.Lerp (guiTextures.color, Color.black, fadeSpeed * Time.deltaTime);

		if (guiTextures.color.a >= 0.95f)
			// ... reload the level.
			SceneManager.LoadScene ("End Screen");
	}

	void calcUsedEnergy(){
		foreach (GameObject appliance in ObjectLists.on) {
			if (appliance.tag == "TV") {
				energyUsed += 220;
				savedEnergy += 80;
			} else {
				energyUsed += 110;
				savedEnergy += 20;
			}
		}
	}

}
