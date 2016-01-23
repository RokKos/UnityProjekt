//Author: Rok Kos <rocki5555@gmail.com>
//File: CameraController.cs
//File path: /D/Documents/Unity/RUN/Assets/Sciprts/CameraController.cs
//Date: 23.1.2016
//Description: Scirpt that controls camera

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//Transform pozicija;
	[SerializeField] GameObject igralec;
	[SerializeField] Camera cam;
	
	// Update is called once per frame
	void Update () {
		cam.transform.position = new Vector3(igralec.transform.position.x,igralec.transform.position.y, igralec.transform.position.z);
	}
}
