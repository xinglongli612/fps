using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
	public GameObject explode;
	public GameObject playerExplode;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObj = GameObject.Find ("GameController");
		if (gameControllerObj != null) {
			gameController = gameControllerObj.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("GameController is null");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) {
			return;
		}
		if (explode != null) {
			Instantiate (explode, transform.position, transform.rotation);
		}
		if (other.tag == "Player") {
			Instantiate (playerExplode, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		} else {
			gameController.AddScores (10);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
