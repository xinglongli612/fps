using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour,IGameManager {
	public ManagerStatus status { get; private set;}
	public int curLevel { get; private set;}
	public int maxLevel { get; private set;}

	private NetworkService _network;

	public void Startup(NetworkService service){
		Debug.Log ("Mission manager starting...");
		_network = service;

		UpdateData (0,1);

		status = ManagerStatus.Started;
	}

	public void UpdateData(int curLevel, int maxLevel){
		this.curLevel = curLevel;
		this.maxLevel = maxLevel;
	}

	public void GoToNext(){
		if (curLevel < maxLevel) {
			curLevel++;
			string name = "Level" + curLevel;
			Debug.Log ("Loading " + name);
			Application.LoadLevel (name);
		} else {
			Debug.Log ("Last Level");
			Messenger.Broadcast (GameEvent.GAME_COMPELTE);
		}
	}

	public void ReachObjective(){
		Messenger.Broadcast (GameEvent.LEVEL_COMPLETE);
	}

	public void RestartCurrent(){
		string name = "Level" + curLevel;
		Debug.Log ("Loading " + name);
		Application.LoadLevel (name);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
