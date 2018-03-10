using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Turret: MonoBehaviour {
	bool GOGOGO;
	Rigidbody2D m_body;
	Vector2 currentPos;
	Select_Turret turret;
	[HideInInspector] public float direction;
	[HideInInspector] public float angle;
	// Use this for initialization
	void Start () {
		GOGOGO = false;
		turret = gameObject.GetComponentInParent<Select_Turret>();
		m_body = GetComponent<Rigidbody2D>();
		currentPos = new Vector2(transform.position.x,transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (turret.aimLoc);
		if (Input.GetKey ("c")) {
			Debug.Log ("A: " + (angle + 90));
			Debug.Log ("D: " + direction);
			Debug.Log ("F: " + Mathf.Abs (direction - angle));
		}
		if (GOGOGO) {
			direction = (Mathf.Atan2 (turret.aimLoc.y - currentPos.y, turret.aimLoc.x - currentPos.x)) * Mathf.Rad2Deg;
			angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, direction - 90, 90 * Time.deltaTime);
			m_body.transform.localRotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			if (Mathf.Abs (direction - angle - 90) < .3f) {
				cancelTurn ();
			}
		}
			
	}

	void cancelTurn(){
		GOGOGO = false;
	}

	public void startTurn(){
		GOGOGO = true;
	}


	public float getDirection(){
		return angle;
	}
}
