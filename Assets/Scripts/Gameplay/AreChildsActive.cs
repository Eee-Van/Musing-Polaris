using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreChildsActive : MonoBehaviour
{

	private bool constDiscovered;

	//--------------------------START---------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//


	//--------------------------UPDATE--------------------------//
	void Update ()
	{
		if (CheckIfStarsAreActive ()) {
			Debug.Log ("Ca  marche!!!!");
		}
	}
	//----------------------------------------------------------//


	//----------------------ARE_STARS_ACTIVE--------------------//
	bool CheckIfStarsAreActive ()
	{

		foreach (Transform child in transform) {
			if (child.GetComponent<ActivateStar> ().active == false) {
				return false;
			}
		}
		return true;
	}
	//----------------------------------------------------------//
}
