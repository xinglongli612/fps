using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour ,IGameManager{

	public ManagerStatus status { get; private set;}

	private string _filename;

	private NetworkService _network;

	public void Startup(NetworkService service){
		Debug.Log ("Data manager starting...");
		_network = service;

		_filename = Path.Combine (Application.persistentDataPath, "game.dat");

		status = ManagerStatus.Started;
	}

	public void SaveGameState(){
		Dictionary<string, object> gameState = new Dictionary<string, object> ();
		gameState.Add ("inventory", Managers.Inventory.GetData());
		gameState.Add ("health", Managers.Player.health);
		gameState.Add ("maxHealth", Managers.Player.maxHealth);
		gameState.Add ("curLevel", Managers.Mission.curLevel);
		gameState.Add ("maxLevel", Managers.Mission.maxLevel);

		FileStream stream = File.Create (_filename);
		BinaryFormatter formatter = new BinaryFormatter ();
		formatter.Serialize (stream, gameState);
		stream.Close ();
	}

	public void LoadGameState(){
		if (!File.Exists (_filename)) {
			Debug.Log ("No saved game");
			return;
		}

		Dictionary<string, object> gameState;
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream stream = File.Open (_filename, FileMode.Open);
		gameState = formatter.Deserialize (stream) as Dictionary<string, object>;
		stream.Close ();

		Managers.Inventory.UpdateData ((Dictionary<string, int>)gameState["inventory"]);
		Managers.Player.UpdateData ((int)gameState["health"], (int)gameState["maxHealth"]);
		Managers.Mission.UpdateData ((int)gameState["curLevel"], (int)gameState["maxLevel"]);
		Managers.Mission.RestartCurrent ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
