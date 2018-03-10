using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Turret_Prediction : MonoBehaviour {
	Vector3 origin;
	LineRenderer line;
	RaycastHit2D collidedWith;
	bool isCollided;
	void Start () {
		origin = transform.position;
		line = GetComponent<LineRenderer> ();
		isCollided = false;
	}
	
	// Update is called once per frame
	void Update () {
		isCollided = false;
        RaycastHit2D[] hit;
		float direction = GetComponent<Rotate_Turret> ().getDirection ();
		direction += 90;
		direction *= Mathf.Deg2Rad;

		hit = Physics2D.RaycastAll (transform.position, new Vector2(60 * Mathf.Cos(direction),60 * Mathf.Sin(direction)));
		collidedWith = hit[0];
		Debug.Log (hit.Length );
		foreach (RaycastHit2D obj in hit){
			if (obj.rigidbody.gameObject.transform != gameObject.transform.parent) {
				collidedWith = obj;
				Debug.Log (collidedWith.rigidbody);
				isCollided = true;
				break;
			}
			//if (obj.rigidbody.gameObject != gameObject) {
			//}
		}
		if (isCollided) {
			line.SetPosition (0, new Vector3(transform.position.x,transform.position.y,14));
			line.SetPosition (1, new Vector3(collidedWith.point.x,collidedWith.point.y,14));
		} else {
			line.SetPosition (0, new Vector3(transform.position.x,transform.position.y,14));
			line.SetPosition (1, new Vector3 (999 * Mathf.Cos (direction), 999 * Mathf.Sin (direction),14));
		}
		//new Vector2(9999 * Mathf.Cos(direction),9999 * Mathf.Sin(direction))
	}
}
