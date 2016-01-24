//Author: Rok Kos <rocki5555@gmail.com>
//File: MakeResources.cs
//File path: /D/Documents/Unity/RUN/UnityProjekt/Assets/Scripts/MakeResources.cs
//Date: 24.1.2016
//Description: Script that makes .txt files of postion of elements
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MakeResources : MonoBehaviour {

	/// <summary>
	/// Funtion that export all elements of same type to txt resources
	/// </summary>
	public void exportToFile(string type){
		//Gets all the element of type
		GameObject[] GetElements = GameObject.FindGameObjectsWithTag(type);
		//open file in Streawriter and at the end automaticly closes file
		using (System.IO.StreamWriter file = 
        new System.IO.StreamWriter(@"D:\Documents\Unity\RUN\UnityProjekt\Assets\Resources\ListOf" + type + ".txt"))
        {
        	//goes throu every elemnt in ucilnice and writes in file
            foreach (GameObject element in GetElements){
            	Vector3 tempVec = element.GetComponent<Transform>().position;
           		file.WriteLine(ParseVector3D(tempVec));
           		//Debug.Log(ParseVector3D(tempVec));
            }
        }			
	}
	/// <summary>
	/// Funtion that imports all elements from file to project
	/// </summary>
	public List<Vector3> readFile(string type){
	//string[] readLines = System.IO.File.ReadAllLines(@"D:\Documents\Unity\GimVicVodic\Assets\ListOfUcilnice.txt");
	TextAsset _textAsset = Resources.Load("ListOf" + type) as TextAsset;
	string[] readLines = _textAsset.text.Split("\n"[0]);
	//temporary list so that doesnt come to duplicates when returning back to Main menu
	List<Vector3> positionsVec3 = new List<Vector3>();
	for(int i=0; i< readLines.Length-1; ++i){
		//Debug.Log(element);
		//element -> vector3.x, vector3.y, vector3.z
		string[] podElementi = readLines[i].Split('|');
		float _pozicijaX = Single.Parse(podElementi[0]);
		float _pozicijaY = Single.Parse(podElementi[1]);
		float _pozicijaZ = Single.Parse(podElementi[2]);
		//TODO: add parsing of roation
		Vector3 tempVec = new Vector3(_pozicijaX, _pozicijaY, _pozicijaZ);
		positionsVec3.Add(tempVec);
		}
	return positionsVec3;
	}

	string ParseVector3D(Vector3 vec){
		return vec.x.ToString() + "|" + vec.y.ToString() + "|" +  vec.z.ToString(); 
	}
}
