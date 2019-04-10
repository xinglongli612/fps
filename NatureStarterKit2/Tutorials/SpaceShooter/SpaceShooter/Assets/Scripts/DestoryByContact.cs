using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		//Debug.Log (other.name);
		if (other.tag == "Boundary") {
			return;
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
