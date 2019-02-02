using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupController : MonoBehaviour {

	[SerializeField] private Slider progressBar;

	void Awake(){
		Messenger.AddListener<int, int> (StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
		Messenger.AddListener (StartupEvent.MANAGERS_STARTED, OnManagersStarted);
	}

	void Destory(){
		Messenger.RemoveListener<int, int> (StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
		Messenger.RemoveListener (StartupEvent.MANAGERS_STARTED, OnManagersStarted);
	}

	private void OnManagersProgress(int numReady, int numModules){
		
	}

	private void OnManagersStarted(){
		Managers.Mission.GoToNext ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
