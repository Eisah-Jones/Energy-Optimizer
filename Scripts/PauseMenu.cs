using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Image menuBox;
	public Text pauseText;
	public Text resume;
	public Text quit;



	// Use this for initialization
	void Start () {
		menuBox.enabled = false;
		pauseText.enabled = false;
		resume.enabled = false;
		quit.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pause ();
		}
	}

	public void pause(){
		if (Time.timeScale == 1) {
			menuBox.enabled = true;
			pauseText.enabled = true;
			resume.enabled = true;
			quit.enabled = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			Time.timeScale = 0;
		} else if (Time.timeScale == 0) {
			menuBox.enabled = false;
			pauseText.enabled = false;
			resume.enabled = false;
			quit.enabled = false;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;
		}
	}

	public void Quit(){
		Time.timeScale = 1;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		SceneManager.LoadScene("Start Screen");
	}
}
