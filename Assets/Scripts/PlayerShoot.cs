﻿//Author: Rok Kos <rocki5555@gmail.com>
//File: PlayerShoot.cs
//File path: /D/Documents/Unity/RUN/UnityProjekt/Assets/Scripts/PlayerShoot.cs
//Date: 23.1.2016
//Description: Script fo shooting

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

	private int damageShot = 20; //how much damage enemy take
	private float timeRafal = 1.0f;
	private float rangeOfBullet = 100.0f;
	private float shootForce = 40.0f;//5000.0f;
	private int scoreInt = 0;
	float timer;  // A timer to determine when to fire.
    Ray shootRay;  // A ray from the gun end forwards.
    RaycastHit targetHit; // A raycast hit to get information about what was hit.
    int shootableMask;// A layer mask so the raycast only hits things on the shootable layer.
    [SerializeField] GameObject scoreText;
    [SerializeField] SpawningEnemije spawningEnemije;
    [SerializeField] GameObject puscica;
    AudioSource ShootSound;
	
	// Use this for initialization
	void Start () {
		shootableMask = LayerMask.GetMask("enemiesMask");
		timer = timeRafal;
		ShootSound = GetComponent<AudioSource>();
	}
	
	/// <summary>
	/// on every update if mouse button press shoot
	/// </summary>
	void Update () {
		timer -= Time.deltaTime;
		if(Input.GetKey (KeyCode.Space) && timer <= 0.0f){
			Shoot();
			timer = timeRafal;
		}
		scoreText.GetComponent<Text>().text ="SCORE: " + scoreInt.ToString();
	}

	public void Shoot(){
        Debug.Log("strelam!");
        ShootSound.Play();
        GameObject projectile = Instantiate(puscica, transform.position + transform.forward * 3.0f, transform.rotation) as GameObject;
        projectile.GetComponent<Rigidbody>().velocity = (projectile.transform.forward * shootForce);

		//Set shoot ray origin and direction
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		//Debug.Log("Shoot");
		//look if raykast hits anything
		if(Physics.Raycast(shootRay, out targetHit, rangeOfBullet, shootableMask)){
			//Debug.Log("Hit");
			//Debug.Log(targetHit.transform);
			//Debug.DrawLine(shootRay.origin, targetHit.point);
			//call funtion taht kils enemie
			targetHit.transform.GetComponent<EnemyControl>().KillEnemie();
			//incresea score
			scoreInt++;
			//shorten time every time by 10%
			spawningEnemije.SpawnTimer -= spawningEnemije.SpawnTimer * 0.1f;
		}
	}

}
