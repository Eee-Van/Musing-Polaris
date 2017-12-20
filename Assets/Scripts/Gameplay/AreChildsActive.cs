using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreChildsActive : MonoBehaviour
{
<<<<<<< HEAD
=======
	public Color constColor;
>>>>>>> master

	public bool constDiscovered;

	//--------------------------START---------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//


	//--------------------------UPDATE--------------------------//
	void Update ()
	{
		if (CheckIfStarsAreActive () && constDiscovered == false) {
			constDiscovered = true; //Once a constellation is Discovered, there's not going back.
			//Should we make it so discovered constellations are saved through play sessions?
		}
	}
	//----------------------------------------------------------//


	//----------------------ARE_STARS_ACTIVE--------------------//
	//This function checks if all the stars in a Constellation parent are Active or not. Returns true if so.
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
