//Author: Rok Kos <rocki5555@gmail.com>
//File: GameController.cs
//File path: /D/Documents/Unity/RUN/Assets/Sciprts/GameController.cs
//Date: 23.1.2016
//Description: Main script
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	[SerializeField] GameObject igralec;
	private float playerSpeed = 10.0f; 
	[SerializeField] Rigidbody rigitBody; //for moving player around
	[SerializeField] Sprite[] lifeImages; //images from whic we pick what to change
	//[SerializeField] Sprite halflife;
	//[SerializeField] Sprite nolife;
	[SerializeField] Image[] SrcekImages; //placeholders where to put images
	[SerializeField] PlayerHealt playerHealt;
	// Use this for initialization
	void Awake() {
		//igralec.transform.position = new Vector3(10.0f, 10.0f, 10.0f); 
	}
	
	void Update () {

		int indexMeja = playerHealt.currHealth/2-1;
		Debug.Log((indexMeja).ToString());
		//change images to full life
		for (int i = 0; i < indexMeja; ++i){
			SrcekImages[i].sprite = lifeImages[2];
		}
		//if there is half life
		if(playerHealt.currHealth%2 == 1){
			//so that we go to next image
			indexMeja++;
			SrcekImages[indexMeja].sprite = lifeImages[1];
			
		}
		//and we go to also to next image
		//and the rest is with no life
		for (int i = indexMeja+1; i < playerHealt.startHealth/2; ++i){
			SrcekImages[i].sprite = lifeImages[0];
		}
	}

	/// <summary>
	/// for calculating physics in every frame
	/// </summary>
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
