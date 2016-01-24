//Author: Rok Kos <rocki5555@gmail.com>
//File: GameController.cs
//File path: /D/Documents/Unity/RUN/Assets/Sciprts/GameController.cs
//Date: 23.1.2016
//Description: Main script
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour {
	[SerializeField] GameObject igralec;
	private float playerSpeed = 10.0f; 
	[SerializeField] Rigidbody rigitBody; //for moving player around
	[SerializeField] Sprite[] lifeImages; //images from whic we pick what to change
	//[SerializeField] Sprite halflife;
	//[SerializeField] Sprite nolife;
	[SerializeField] Image[] SrcekImages; //placeholders where to put images
	[SerializeField] PlayerHealt playerHealt;
	[SerializeField] GameObject hud; //for disabling and enabling
	[SerializeField] GameObject pauseMenu; //for disabling and enabling
	[SerializeField] MakeResources makeResources;
	List<Vector3> listOfSmreka = new List<Vector3>(); //list of postion where to spawn
	[SerializeField] GameObject prefabSmreka;
	//complex dictionary for populating
	Dictionary<string, KeyValuePair<List<Vector3>, GameObject> > pariForPopulation = new Dictionary<string, KeyValuePair<List<Vector3>, GameObject> >();

	// Use this for initialization
	void Awake() {
		//igralec.transform.position = new Vector3(10.0f, 10.0f, 10.0f);
		hud.SetActive(true);
		pauseMenu.SetActive(false);
		//get postion so that u can spawn objects
		//makeResources.exportToFile("Smreka");
		listOfSmreka = makeResources.readFile("Smreka"); 
		//adding pairs
		pariForPopulation.Add("Smreka", new KeyValuePair<List<Vector3>, GameObject>(listOfSmreka, prefabSmreka));
		//pariForPopulation.Add("Bor", new Tuple<List<Vector3>, GameObject>(listOfBor, prefabBor));
		//pariForPopulation.Add("Hisa", new Tuple<List<Vector3>, GameObject>(listOfHisa, prefabHisa));

		//populate world
		PopulateWorld();
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
	/// <summary>
	/// show or disables pause menu and bring or hides HUD menu
	/// WARNING only one box in unity editor sets th valuable of parameter
	/// if true then hud is enabled Pause menu disabled
	/// if false then hud disabled and Pause menu enabled
	/// </summary>
	public void gotoPauseMenu(bool value){
		hud.SetActive(value);
		pauseMenu.SetActive(!value);
		if(value){Time.timeScale = 1.0f;}
		else{Time.timeScale = 0.0f;}
	}
	/// <summary>
	///Goes thru all pair and populate wold with them
	/// </summary>
	void PopulateWorld(){
		//going throu all pairs
		foreach (KeyValuePair<string, KeyValuePair<List<Vector3>, GameObject> > elem in pariForPopulation){
			//Gets vector
			List<Vector3> tempList = elem.Value.Key;
			GameObject tempGamObj = elem.Value.Value;
			for (int i =0; i < tempList.Count; ++i){
				Instantiate(tempGamObj, tempList[i], Quaternion.identity);
			}
		} 

	}

	public void gotoMainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
