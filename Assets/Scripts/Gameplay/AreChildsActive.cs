using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreChildsActive : MonoBehaviour
{
	public Color constColor;

	public bool constDiscovered;

	//--------------------------START---------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//


	//--------------------------UPDATE--------------------------//
	void Update ()
	{
		if (constDiscovered == false) {
			if (CheckIfStarsAreActive ()) {
				constDiscovered = true; //Once a constellation is Discovered, there's not going back.
				DrawLinks[] drawLinks = GetComponentsInChildren<DrawLinks> (); //Choppe tous les Drawlinks enfants
				ParticleSystem[] childrenPS = GetComponentsInChildren<ParticleSystem> ();
				foreach (ParticleSystem CPS in childrenPS) {
					CPS.Play ();
					CPS.Emit (1);
				}
				foreach (DrawLinks scriptToActivate in drawLinks) {
					scriptToActivate.enabled = true; //Active chacun d'entre eux
				}

			}//Should we make it so discovered constellations are saved through play sessions?
		}
	}
	//----------------------------------------------------------//


	//----------------------ARE_STARS_ACTIVE--------------------//
	//This function checks if all the stars in a Constellation parent are Active or not. Returns true if so.
	bool CheckIfStarsAreActive ()
	{

		foreach (Transform child in transform) {
			if (child.gameObject.GetComponent<ActivateStar> () != null) {
				if (child.gameObject.GetComponent<ActivateStar> ().active == false) {
					return false;
				}
			}
		}
		print ("1");

		return true;
	}
	//----------------------------------------------------------//
}
