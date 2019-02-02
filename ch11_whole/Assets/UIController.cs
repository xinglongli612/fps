using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] private Text healthLabel;
	[SerializeField] private Text levelEnding;
	[SerializeField] private InventoryPopup popup;

	public void SaveGame(){
		Managers.Data.SaveGameState ();
	}

	public void LoadGame(){
		Managers.Data.LoadGameState ();
	}

	private void OnHealthUpdated(){
		string message = "Health: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
		healthLabel.text = message;
	}

	void Awake(){
		Messenger.AddListener (GameEvent.HEALTH_UPDATED, OnHealthUpdated);
		Messenger.AddListener (GameEvent.LEVEL_COMPLETE, OnLevelComplete);
		Messenger.AddListener (GameEvent.LEVEL_FAILED, OnLevelFailed);
		Messenger.AddListener (GameEvent.GAME_COMPELTE, OnGameComplete);
	}

	void OnDestory(){
		Messenger.RemoveListener (GameEvent.HEALTH_UPDATED, OnHealthUpdated);
		Messenger.RemoveListener (GameEvent.HEALTH_UPDATED, OnLevelComplete);
		Messenger.RemoveListener (GameEvent.LEVEL_FAILED, OnLevelFailed);
		Messenger.RemoveListener (GameEvent.GAME_COMPELTE, OnGameComplete);
	}

	private void OnLevelComplete(){
		StartCoroutine (CompleteLevel());
	}

	private IEnumerator CompleteLevel(){
		levelEnding.gameObject.SetActive (true);
		levelEnding.text = "Level Complete!";
		yield return new WaitForSeconds (2);
		Managers.Mission.GoToNext ();
	}

	private void OnLevelFailed(){
		StartCoroutine (FailedLevel());
	}

	private void OnGameComplete(){
		levelEnding.gameObject.SetActive (true);
		levelEnding.text = "You Finished the Game!";
	}

	private IEnumerator FailedLevel(){
		levelEnding.gameObject.SetActive (true);
		levelEnding.text = "Level Failed";
		yield return new WaitForSeconds (2);
		Managers.Player.Respawn ();
		Managers.Mission.RestartCurrent ();
	}

	// Use this for initialization
	void Start () {
		OnHealthUpdated ();
		levelEnding.gameObject.SetActive (false);
		popup.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			bool isShowing = popup.gameObject.activeSelf;
			popup.gameObject.SetActive (!isShowing);
			popup.Refresh ();
		}
	}

}
