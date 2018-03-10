using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Turret : MonoBehaviour {
	private bool isSelected;
	private bool recentlySelected;
	private bool aimPlaced;
	public Vector2 aimLoc;
	public GameObject selectTurretPrefab;
	GameObject selectedTurretCircle;
	public GameObject aimPrefab;
	GameObject aimCircle;
	// Use this for initialization
	void Start () {
		aimLoc = new Vector2(0,0);
		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1) && isSelected == true) {
			aimLoc = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (aimPlaced == false) {
				aimCircle = Instantiate (aimPrefab, aimLoc, Quaternion.identity);
				aimPlaced = true;
			} else {
				GameObject.Destroy (aimCircle);
				aimCircle = Instantiate (aimPrefab, aimLoc, Quaternion.identity);
			}
		}
		if (recentlySelected) {
			createSquare ();
			if (aimPlaced) {
				aimCircle = Instantiate (aimPrefab, aimLoc, Quaternion.identity);
			}
		}
	}

	void OnMouseDown(){
		isSelected = true;
		recentlySelected = true;
	}

	void createSquare(){
		recentlySelected = false;
		selectedTurretCircle = Instantiate(selectTurretPrefab,transform.position,Quaternion.identity);
	}

	public void deselect(){
		GameObject.Destroy (selectedTurretCircle);
		isSelected = false;
		GameObject.Destroy (aimCircle);
	}
}
