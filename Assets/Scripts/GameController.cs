//Author: Rok Kos <rocki5555@gmail.com>
//File: GameController.cs
//File path: /D/Documents/Unity/RUN/Assets/Sciprts/GameController.cs
//Date: 23.1.2016
//Description: Main script
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	[SerializeField] GameObject igralec;
	private float playerSpeed = 10.0f; 
	[SerializeField] Rigidbody rigitBody;
	// Use this for initialization
	void Awake() {
		//igralec.transform.position = new Vector3(10.0f, 10.0f, 10.0f); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {	
		if(Input.GetKey (KeyCode.RightArrow)){
			//Debug.Log("here");
			float newXcordinate = + playerSpeed * Time.deltaTime;//igralec.transform.position.x  
			//igralec.transform.position = new Vector3(newXcordinate, igralec.transform.position.y, igralec.transform.position.z);
			rigitBody.MovePosition(igralec.transform.position + new Vector3(newXcordinate,0,0));

		}
		if(Input.GetKey (KeyCode.LeftArrow)){
			//Debug.Log("her2");
			float newXcordinate = - playerSpeed * Time.deltaTime;//igralec.transform.position.x  
			//igralec.transform.position = new Vector3(newXcordinate, igralec.transform.position.y, igralec.transform.position.z);
			rigitBody.MovePosition(igralec.transform.position + new Vector3(newXcordinate,0,0));
		}
		if(Input.GetKey (KeyCode.UpArrow)){
			//Debug.Log("here3");
			float newZcordinate = + playerSpeed * Time.deltaTime;//igralec.transform.position.z  
			//igralec.transform.position = new Vector3(igralec.transform.position.x, igralec.transform.position.y, newZcordinate);
			rigitBody.MovePosition(igralec.transform.position + new Vector3(0,0,newZcordinate));
		}
		if(Input.GetKey (KeyCode.DownArrow)){
			//Debug.Log("her4");
			float newZcordinate = - playerSpeed * Time.deltaTime;//igralec.transform.position.z  
			//igralec.transform.position = new Vector3(igralec.transform.position.x, igralec.transform.position.y, newZcordinate);
			rigitBody.MovePosition(igralec.transform.position + new Vector3(0,0,newZcordinate));
		}
	}
}
