using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Turret: MonoBehaviour {
	bool GOGOGO;
	Rigidbody2D m_body;
	Vector2 currentPos;
	Select_Turret turret;
	// Use this for initialization
	void Start () {
		GOGOGO = false;
		turret = gameObject.GetComponentInParent<Select_Turret>();
		m_body = GetComponent<Rigidbody2D>();
		Debug.Log (currentPos);
		currentPos = new Vector2(transform.position.x,transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (turret.aimLoc);
		if (Input.GetKey ("a")) {
			GOGOGO = true;
		}
		if (Input.GetKey ("b")) {
			cancelTurn ();
		}
		if (GOGOGO) {
			float direction = (Mathf.Atan2 (turret.aimLoc.y - currentPos.y, turret.aimLoc.x - currentPos.x)) * Mathf.Rad2Deg;
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, direction - 90, 90 * Time.deltaTime);
			m_body.transform.localRotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
		}
			
	}

	void cancelTurn(){
		GOGOGO = false;
	}
}
