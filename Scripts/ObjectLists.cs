using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectLists : MonoBehaviour {

	public static List<GameObject> off;

	public static List<GameObject> on;

	// Use this for initialization
	void Start () {
		off = GameObject.FindGameObjectsWithTag ("switches").ToList();
		off.AddRange (GameObject.FindGameObjectsWithTag ("TV").ToList ());
		off.AddRange (GameObject.FindGameObjectsWithTag ("lamp").ToList ());
		on = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static List<GameObject> GetOff(){
		return off;
	}

	public static List<GameObject> GetOn(){
		return on;
	}

	public static void AddItem(GameObject other){
		//Add an object to the ON list and remove it from the OFF list
		on.Add (other);
	}

	public static void RemoveItem(GameObject other){
		on.Remove (other);
	}
}
