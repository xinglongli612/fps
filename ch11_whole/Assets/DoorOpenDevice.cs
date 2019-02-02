using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpenDevice : MonoBehaviour {

	[SerializeField] private Vector3 dPos;
	private bool _open;

//	public void Operate(){
//		if (_open) {
//			//transform.position -= dPos;
//			transform.DOMove (transform.position - dPos, 3);
//		} else {
//			//transform.position += dPos;
//			transform.DOMove (transform.position + dPos, 3);
//		}
//		_open = !_open;
//	}

	public void Activate(){
		if (!_open) {
			transform.DOMove (transform.position + dPos, 3);
			_open = true;
		}	
	}

	public void Deactivate(){
		if (_open) {
			transform.DOMove (transform.position - dPos, 3);
			_open = false;
		}	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
