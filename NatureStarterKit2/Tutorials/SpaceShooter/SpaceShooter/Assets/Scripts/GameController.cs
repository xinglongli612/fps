using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazards;
	public Vector3 spawnPos;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start () {
		StartCoroutine (SpawnWaves());
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
			yield return new WaitForSeconds (waveWait);
		}
	}
}
