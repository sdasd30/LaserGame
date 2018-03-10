using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool isTurn;
	Rotate_Turret[] turrets;
	// Use this for initialization
	void Start () {
		turrets = FindObjectsOfType<Rotate_Turret>();
		isTurn = false;
	}

	public void BeginTurn(){
		isTurn = true;
	}

	public void EndTurn(){
		isTurn = false;
		foreach (Rotate_Turret tur in turrets){
			tur.went = false;
		}
	}
}
