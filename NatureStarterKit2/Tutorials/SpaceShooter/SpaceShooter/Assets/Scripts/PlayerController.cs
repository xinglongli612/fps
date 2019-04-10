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
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;
	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical"); 
		Vector3 movement = new Vector3(moveHorizontal, 0.0f,moveVertical);
		rb.velocity = movement * 3.5f;
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, movement.x * -15.5f);
	}
}
