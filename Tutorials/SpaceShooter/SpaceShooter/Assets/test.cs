using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	void Update(){
		Vector3 s0 = transform.position;
		Vector3 s1 = transform.forward;
		Vector3 s2 = transform.up;
		Vector3 s3 = transform.right;
		Vector3 s4 = Vector3.up;
		Vector3 s5 = Vector3.right;
		Vector3 s6 = Vector3.forward;
		int s = 1;
		//transform.position = transform.position + s6 * 0.01f;
		//transform.Translate (s1* 0.01f,Space.World);
		transform.Translate (s6 * 0.01f, Space.Self);
	}
}
