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
	private float angleOfDeath = 180.0f; //for what angle enemie rotate when dies
	private float timeAttack = 2.0f;
	PlayerHealt playerHealt;
	private bool uCanAttack = false;

	// Use this for initialization
	void Awake () {
		//get agent
		agent = GetComponent<NavMeshAgent>();
		//find player in scene
		igralec = GameObject.Find("Igralec");
		playerHealt = igralec.GetComponent<PlayerHealt>();
	}
	
	/// <summary>
	/// enemy follow player, changing destination every frame
	/// Attack player if in range
	/// </summary>
	void Update () {
		agent.SetDestination(igralec.transform.position);
		timeAttack -= Time.deltaTime;
		//check if player is in range and if not dead and if enoug time alapsed
		if(uCanAttack && timeAttack <= 0.0f && playerHealt.currHealth > 0 ){
			playerHealt.TakeDamage(20);
			timeAttack = 2.0f;
		}
	}

	/// <summary>
	/// TODO: 
	/// Kill enemie with simple anymation
	/// with coroutine so that we dont need to call in update method
	/// and in every frame it does rotate for some angle
	/// </summary>
	public void KillEnemie(){ //IEnumerator
		/*
		while(angleOfDeath > 0){
			Debug.Log(angleOfDeath.ToString());
			angleOfDeath -= 1.0f;
			transform.Rotate(transform.rotation.x + 1.0f, transform.rotation.y, transform.rotation.z);//, Space.Self);
			yield return null;
		}
		Debug.Log("Destroy");
		*/
		Destroy(gameObject, 0);
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject == igralec){
			uCanAttack = true;
		}
	}

	void OnTriggerExit(Collider coll){
		if(coll.gameObject == igralec){
			uCanAttack = false;
		}
	}
}
