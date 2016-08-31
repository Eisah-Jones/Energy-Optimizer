using UnityEngine;
using System.Collections;

public class EndInfo : MonoBehaviour {

	public static string winOrLose;
	public static int energyUsed;
	public static int energySaved;

	public void Start(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public static void setWin(string s){
		winOrLose = s;
	}

	public static void setEnergy (int i, int s){
		energyUsed = i;
		energySaved = s;
	}
}
