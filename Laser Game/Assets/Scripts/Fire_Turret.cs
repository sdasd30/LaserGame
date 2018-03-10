using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Fire_Turret : MonoBehaviour {

	public float bounceLimit;
	public float damage;
	[HideInInspector] public bool hasFired;
	private LineRenderer line;
	RaycastHit2D collidedWith;
	bool isCollided;
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
		hasFired = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasFired == false){
			line.SetVertexCount (2);
			isCollided = false;
			RaycastHit2D[] hit;
			float direction = GetComponent<Rotate_Turret> ().getDirection ();
			direction += 90;
			direction *= Mathf.Deg2Rad;

			hit = Physics2D.RaycastAll (transform.position, new Vector2(60 * Mathf.Cos(direction),60 * Mathf.Sin(direction)));
			collidedWith = hit[0];
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
			hasFired = true;
			Invoke ("disableLineRenderer",3);
		}

	}

	void disableLineRenderer(){
		line.SetVertexCount (0);
	}
		
}
