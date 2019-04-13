using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {
	public float speed;
	public float tileSize;
	public Vector3 startPosition;
	void Start(){
		startPosition = transform.position;
	}
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * speed, tileSize);
		//Debug.Log (newPosition);
		transform.position = startPosition + Vector3.forward * newPosition;
		//Debug.Log (transform.position);
	}
}
