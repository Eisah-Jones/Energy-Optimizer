using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour {

	public Text winLose;
	public Text energyUse;
	public Text energySave;
	public Text playAgain;
	public Text Quit;
	public AudioSource winMusic;
	public AudioSource loseMusic;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		if (EndInfo.winOrLose == "win") {
			winLose.text = "You Won!";
			winMusic.Play ();
		} else {
			winLose.text = "You ran out of energy!";
			loseMusic.Play();
		}

		energyUse.text = "You used\n" + EndInfo.energyUsed.ToString() + " watts \nof energy today";
		energySave.text = "Energy efficient appliances could have saved you\n" + (EndInfo.energyUsed - EndInfo.energySaved).ToString() + " watts";
	}



	public void quitter(){
		SceneManager.LoadScene (0);
	}

	public void playAgainer(){
		SceneManager.LoadScene (1);
	}
}
