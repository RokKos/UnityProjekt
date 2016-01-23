//Author: Rok Kos <rocki5555@gmail.com>
//File: EnemyControl.cs
//File path: /D/Documents/Unity/RUN/UnityProjekt/Assets/Sciprts/EnemyControl.cs
//Date: 23.1.2016
//Description: Script that controls enemy
using UnityEngine;
using System.Collections;

public class EnemyControl: MonoBehaviour {
	NavMeshAgent agent;
	GameObject igralec; //for postion of player
	
	// Use this for initialization
	void Awake () {
		//get agent
		agent = GetComponent<NavMeshAgent>();
		//find player in scene
		igralec = GameObject.Find("Igralec"); 
	}
	
	/// <summary>
	/// enemy follow player, changing destination every frame
	/// </summary>
	void Update () {
		agent.SetDestination(igralec.transform.position);

	}
}
