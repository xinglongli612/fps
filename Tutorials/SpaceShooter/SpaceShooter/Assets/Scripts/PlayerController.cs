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

	private float moveHorizontal1;
	private float moveVertical1;
	void Start(){
		Input.gyro.enabled = true;
		moveHorizontal1 = Input.gyro.attitude.x;
		moveVertical1 = Input.gyro.attitude.y; 
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
		moveHorizontal1 = Input.gyro.attitude.x - moveHorizontal1;
		moveVertical1 = Input.gyro.attitude.y - moveVertical1; 
		moveHorizontal1 = float.Parse (moveHorizontal1.ToString ("#0.00"));
		moveVertical1 = float.Parse (moveVertical1.ToString ("#0.00"));
		//GUILayout.Label ("gyroX : " + moveHorizontal1);
		//GUILayout.Label ("gyroY : " + moveVertical1);
		Vector3 movement = new Vector3(moveHorizontal1, 0.0f,moveVertical1);
		rb.velocity = movement * 30.0f;
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, movement.x * -15.5f);
	}

	protected void OnGUI()
	{
		GUILayout.Label ("gyroX : " + moveHorizontal1);
		GUILayout.Label ("gyroY : " + moveVertical1);
	}
}
