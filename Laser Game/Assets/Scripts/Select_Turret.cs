using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Turret : MonoBehaviour {
	private bool isSelected;
	public Vector2 aimLoc;
	// Use this for initialization
	void Start () {
		aimLoc = new Vector2(0,0);
		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1) && isSelected == true) {
			aimLoc = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
	}

	void OnMouseDown(){
		isSelected = true;
	}
}
