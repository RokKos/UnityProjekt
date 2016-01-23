//Author: Rok Kos <rocki5555@gmail.com>
//File: GameController.cs
//File path: /D/Documents/Unity/RUN/Assets/Sciprts/GameController.cs
//Date: 23.1.2016
//Description: Main script
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	[SerializeField] GameObject igralec;
	private float playerSpeed = 60.0f; 
	// Use this for initialization
	void Awake() {
		igralec.transform.position = new Vector3(0.0f, 2.6f, 0.0f); 
	}
	
	// Update is called once per frame
	void Update () {	
		if(Input.GetKeyDown (KeyCode.UpArrow)){
			Debug.Log("here");
			float newXcordinate = igralec.transform.position.x + playerSpeed * Time.deltaTime;
			igralec.transform.position = new Vector3(newXcordinate, igralec.transform.position.y, igralec.transform.position.z);
		}
	}
}
