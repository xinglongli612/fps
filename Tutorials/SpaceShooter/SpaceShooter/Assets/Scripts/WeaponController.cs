using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", 2, 3);	
	}

	void Fire(){
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}
}
