using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager {
	public ManagerStatus status { get; private set;}

	private NetworkService _network;

	public void Startup(NetworkService service){
		Debug.Log ("Weather manager starting...");
		_network = service;
		status = ManagerStatus.Started;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
