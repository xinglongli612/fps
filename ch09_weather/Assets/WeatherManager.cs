using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager {
	public ManagerStatus status { get; private set;}

	private NetworkService _network;

	public void Startup(NetworkService service){
		Debug.Log ("Weather manager starting...");
		_network = service;
		//StartCoroutine (_network.GetWeatherXML(OnXMLDataLoaded));
		status = ManagerStatus.Started;
	}

	public void OnXMLDataLoaded(string data){
		Debug.Log (data);
		status = ManagerStatus.Started;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
