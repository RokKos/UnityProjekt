//Author: Rok Kos <rocki5555@gmail.com>
//File: SpawningEnemije.cs
//File path: /D/Documents/Unity/RUN/UnityProjekt/Assets/Sciprts/SpawningEnemije.cs
//Date: 23.1.2016
//Description: Script for spawning enemies
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawningEnemije : MonoBehaviour {

	[SerializeField] GameObject[] kmetiPrefab;
	//[SerializeField] GameObject kmeticaPrefab;
	List<Vector3> spawnPoints = new List<Vector3>();
	[SerializeField] GameObject igralec;
	private float SpawnTimer = 1.0f; //time to spawn enemies

	// Use this for initialization
	void Awake () {
		GameObject[] foundGameObj = GameObject.FindGameObjectsWithTag("Spawn");
		foreach (GameObject elem in foundGameObj) {
			spawnPoints.Add(elem.transform.position);			
		}
	}
	
	/// <summary>
	/// on every second spawn enemy on spawn point
	/// </summary>
	void Update () {
		//if time is at zero
		if(SpawnTimer <=0.0f){
			SpawnTimer = 3.0f;
			//decide randomly where to spawn
			int poz = Random.Range(0,4);
			//what to spawn...
			int type = Random.Range(0,3);
			//spawning enemie
			GameObject enemie = Instantiate(kmetiPrefab[type], spawnPoints[poz], Quaternion.identity) as GameObject;
		}
		SpawnTimer -= Time.deltaTime;
	}
}
