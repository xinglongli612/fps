using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	public float speed = 3.0f;
	public float baseSpeed = 3.0f;
	void Awake(){
		Messenger.AddListener<float> (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void OnDestory(){
		Messenger.RemoveListener<float> (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	private void OnSpeedChanged (float value){
		speed = baseSpeed * value;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemy == null){
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3 (0, 1, 0);
			WanderingAI ai = _enemy.GetComponent<WanderingAI>();
			ai.speed = speed;
			float angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);
		}	
	}
}
