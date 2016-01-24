//Author: Rok Kos <rocki5555@gmail.com>
//File: UIControler.cs
//File path: /D/Documents/Unity/RUN/UnityProjekt/Assets/Scripts/UIControler.cs
//Date: 23.1.2016
//Description: Script for controling UI

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIControler : MonoBehaviour {

	GameObject[] findGameObj;// = new List<string>();
	GameObject trenutniGameObject;
	[SerializeField] GameObject contentCanvas;
	[SerializeField] Image img;

	// Use this for initialization
	void Awake () {
		findGameObj = GameObject.FindGameObjectsWithTag("Menu");
		enableMenu("MainMenu");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// Change menu according to button
	/// </summary>
	public void ChangeMenu(Button selectedButton){
		string regexButton = "Button";
		//parse name of button to right menu
		string strMenu = selectedButton.name.Remove(selectedButton.name.IndexOf(regexButton), regexButton.Length) + "Menu";
		//call funtion to enable the menu
		enableMenu(strMenu);
	}
	/// <summary>
	/// Enable only one menu and disable everyone else
	/// </summary>
	void enableMenu(string nameOfMenu){
		foreach (GameObject elem in findGameObj) {
			if(elem.name == nameOfMenu){
				elem.SetActive(true);
				//if(elem.name == "ShopMenu"){
					//load all weapons from resources
					//GameObject[] contentPrefabs =  Resources.LoadAll("Weapons") as GameObject[];
					//Debug.Log(contentPrefabs.Length.ToString());
					//go thru all of them
					//foreach (GameObject tempPrefab in contentPrefabs){
						//populate content menu
					//	CreateButton(tempPrefab);
					//}
				//}
			}else{
				elem.SetActive(false);
			}
			
		}
	}
	/// <summary>
	/// Goes to Main level
	/// </summary>
	public void gotoMain(){
		Application.LoadLevel("main");
	}

	public void changePicture(Button clickedButton){
		Debug.Log("here");
		Sprite tempSprite = clickedButton.GetComponent<Image>().sprite;
		img.sprite = tempSprite;
		img.color = new Color(1f, 1f, 1f, 1.0f);
	}

	void CreateButton(GameObject prefabButton){
		GameObject insButton = Instantiate(prefabButton) as GameObject;
		//set paretn to our canvas so that is perfectly lined with button
		insButton.transform.SetParent(contentCanvas.transform, false);

	}
}
