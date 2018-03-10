using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Turret: MonoBehaviour {
	bool GOGOGO;
	public bool went;
	Rigidbody2D m_body;
	Vector2 currentPos;
	Select_Turret turret;
	GameObject manager;
	[HideInInspector] public float direction;
	[HideInInspector] public float angle;
	// Use this for initialization
	void Start () {
		went = false;
		manager = FindObjectOfType<GameManager> ().gameObject;
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

		if (manager.GetComponent<GameManager> ().isTurn && !went) {
			faceDirection ();
		}
			
	}

	void cancelTurn(){
		went = true;
		StartCoroutine(WaitOneSecond());
		GetComponent<Fire_Turret> ().hasFired = false;
	}

	void faceDirection(){
		direction = (Mathf.Atan2 (turret.aimLoc.y - currentPos.y, turret.aimLoc.x - currentPos.x)) * Mathf.Rad2Deg;
		angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, direction - 90, 90 * Time.deltaTime);
		m_body.transform.localRotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
		if (Mathf.Abs (direction - angle - 90) < .3f) {
			cancelTurn ();
		}

	}
		

	public float getDirection(){
		return angle;
	}

	IEnumerator WaitOneSecond()
	{
		yield return new WaitForSeconds(1);
	}
}
