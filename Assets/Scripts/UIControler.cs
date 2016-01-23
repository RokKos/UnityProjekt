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
			}else{
				elem.SetActive(false);
			}
			
		}
	}
}
