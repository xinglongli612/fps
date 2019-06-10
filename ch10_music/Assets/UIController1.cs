using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController1 : MonoBehaviour {

	[SerializeField] private SettingsPopup1 popup;

	// Use this for initialization
	void Start () {
		popup.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M)){
			bool isShowing = popup.gameObject.activeSelf;
			popup.gameObject.SetActive (!isShowing);
			if (isShowing) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;	
			}
		}
	}
}
