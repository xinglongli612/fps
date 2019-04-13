using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public Boundary boundary;
	private Rigidbody rb;
	private AudioSource auto;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;
	void Start(){
		Input.gyro.enabled = true;
		rb = GetComponent<Rigidbody> ();
		auto = GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			auto.Play ();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical"); 
		float moveHorizontal1 = Input.gyro.attitude.x;
		float moveVertical1 = Input.gyro.attitude.y; 
		Debug.Log ("x : " + moveHorizontal);
		Debug.Log ("y : " + moveVertical);
		Debug.Log ("gyroX : " + moveHorizontal1);
		Debug.Log ("gyroY : " + moveVertical1);
		Vector3 movement = new Vector3(moveHorizontal1, 0.0f,moveVertical1);
		rb.velocity = movement * 20.5f;
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, movement.x * -15.5f);
	}
}
