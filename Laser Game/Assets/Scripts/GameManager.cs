using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool isTurn;
	Fire_Turret[] turrets;
	Select_Turret prevSelect;
	List<GameObject> turnObjects;
	// Use this for initialization
	void Start () {
		turrets = FindObjectsOfType<Fire_Turret>();
		isTurn = false;
		turnObjects = new List<GameObject> ();
	}

	public void BeginTurn(){
		isTurn = true;
		foreach (Fire_Turret turret in turrets) {
			turret.gameObject.GetComponent<Rotate_Turret>().went = false;
			//turret.hasFired = false;
		}
		/*TurnManager [] tma = FindObjectsOfType<TurnManager> ();
		foreach (TurnManager t in tma) {
			turnObjects.Add (t.gameObject);
		}

		turnObjects = turnSort (turnObjects);

		foreach(GameObject obj in turnObjects){
			obj.GetComponent<Rotate_Turret> ().went = false;
			waitThreeSeconds ();
		}
		*/
	}

	public void EndTurn(){
		isTurn = false;
	}

	public void updateSelection(Select_Turret turret){
		if (prevSelect != null) {
			prevSelect.deselect ();
		}
		prevSelect = turret;
	}

	public List<GameObject> turnSort(List<GameObject> oldArr){
		List<GameObject> newArray = new List<GameObject>(oldArr.Count);
		//newArray.Capacity = oldArr.Count;
		Debug.Log (oldArr);
		foreach (GameObject obj in oldArr) {
			Debug.Log (obj.GetComponent<TurnManager>().getTurn ());
			newArray[obj.GetComponent<TurnManager>().getTurn ()] = obj;
		}
		//Debug.Log (newArray);
		return newArray;
	}
		
	IEnumerator waitThreeSeconds(){
		yield return new WaitForSeconds (4);
	}
}
