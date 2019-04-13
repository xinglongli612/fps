using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazards;
	public Vector3 spawnPos;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	private int score;

	private bool gameOver = false;
	private bool restart = false;

	void Start () {
		score = 0;
		UpdateScore ();
		//gameOverText.text = "";
		//restartText.text = "";
		StartCoroutine (SpawnWaves());
	}

	void Update(){

	}

	public void AddScores(int s){
		score += s;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	IEnumerator SpawnWaves (){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 position = new Vector3 (Random.Range(-spawnPos.x, spawnPos.x), spawnPos.y, spawnPos.z);
				Quaternion rotation = Quaternion.identity;
				Instantiate(hazards, position, rotation);
				yield return new WaitForSeconds (spawnWait);
			}
			if (gameOver) {
				//restartText.text = "Press 'R' for Restart";
				//restart = true;
				//break;
				gameOver = false;
				Application.LoadLevel (Application.loadedLevel);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
