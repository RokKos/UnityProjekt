//Author: Rok Kos <rocki5555@gmail.com>
//File: PlayerHealt.cs
//File path: /D/Documents/Unity/RUN/UnityProjekt/Assets/Scripts/PlayerHealt.cs
//Date: 23.1.2016
//Description: Script for player health
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour {
	private int startHealth = 100;
	public int currHealth;
	[SerializeField] Image udarecImage;
	private float flashSpeed = 1.0f;
	private Color flashColour = new Color(1f, 0f, 0f, 0.3f);
	public bool damaged = false;
	private bool isDeath = false;
	
	// Use this for initialization
	void Awake () {
		currHealth = startHealth;
	}
	
	/// <summary>
	/// shows if player is damgaded
	/// and calls funtions for player deadt if so
	/// </summary>
	void Update () {
		//if hit set image to that color	
		if(damaged){
			
			udarecImage.color = flashColour;
		}
		//else degrade image
		else{
			udarecImage.color = Color.Lerp (udarecImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		//reset to not duplicate effect
		damaged = false;	
	}
	/// <summary>
	/// tell player that u take damage
	/// </summary>
	public void TakeDamage(int damageValue){
		damaged = true;
		currHealth -= damageValue;
		if(currHealth <= 0 && !isDeath){
			Death();
		}	
	}
	/// <summary>
	/// kill the player and stop the game
	/// </summary>
	void Death(){
		Time.timeScale = 0;
		isDeath = true;
	}
}
