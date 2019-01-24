using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel;
	[SerializeField] private SettingsPopup settingsPopup;
	private int _score;

	private void OnEnemyHit(){
		_score += 1;
		scoreLabel.text = _score.ToString ();
	}

	void Awake(){
		Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	void OnDestory(){
		Messenger.RemoveListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	// Use this for initialization
	void Start () {
		_score = 0;
		scoreLabel.text = _score.ToString ();
		settingsPopup.Close ();
	}
	
	// Update is called once per frame
	void Update () {
		//scoreLabel.text = Time.realtimeSinceStartup.ToString ();
	}

	public void OnOpenSettings(){
		settingsPopup.Open ();
	}
}
