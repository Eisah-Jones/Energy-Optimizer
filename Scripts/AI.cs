using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AI : MonoBehaviour {

	private NavMeshAgent nav;
	private GameObject target;
	private int listSize;
	private static List<GameObject> off;
	private string currentName;
	private float time = 0.0f;

	// Use this for initialization
	void Start () {
		target = null;
		off = null;
		currentName = null;
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		off = ObjectLists.GetOff();
		listSize = off.Count();
		if(listSize == 0){
			Debug.Log("EMPTY");
		}
		else if (target == null){
			target = off[Random.Range(0, listSize)];
			currentName = target.name;
			nav.SetDestination (target.transform.position);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name == currentName) {
			if (other.tag == "switches") {
				other.GetComponent<LightSwitch>().Switch ();
			}
			if (other.tag == "lamp") {
				other.GetComponent<LampSwitch>().Switch ();
			}
			if (other.tag == "TV") {
				other.GetComponent<InteractTV>().Switch ();
			}

			target = null;
		}
	}

	void OnTriggerStay(Collider other){
		time += Time.deltaTime;
		if (time > 1.0f) {
			target = null;
		}

	}

	void OnTriggerExit(){
		time = 0.0f;
	}

	void OnCollisionEnter(Collision other){
		if (other.collider.tag == "AI" | other.collider.tag == "Player") {
			Physics.IgnoreCollision (other.collider, GetComponent<Collider> ());
		}
	}
}

