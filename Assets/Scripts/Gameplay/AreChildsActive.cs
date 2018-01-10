using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreChildsActive : MonoBehaviour
{

	public bool constDiscovered;
	public GameObject[] starChildren;
	public Color constColor;


	//--------------------------START---------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//


	//--------------------------UPDATE--------------------------//
	void Update ()
	{
		if (constDiscovered == false) {
<<<<<<< HEAD
			if (CheckIfStarsAreActive ())
				constDiscovered = true; //Once a constellation is Discovered, there's not going back.
			//Should we make it so discovered constellations are saved through play sessions?
=======
			if (CheckIfStarsAreActive ()) {
				constDiscovered = true; //Once a constellation is Discovered, there's not going back.
				DrawLinks[] drawLinks = GetComponentsInChildren<DrawLinks> (); //Choppe tous les Drawlinks enfants
				foreach (DrawLinks scriptToActivate in drawLinks) {
					scriptToActivate.enabled = true; //Active chacun d'entre eux
				}

			}//Should we make it so discovered constellations are saved through play sessions?
>>>>>>> Caroline
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
				break;
			}
		}
<<<<<<< HEAD
		//Here there should be a "for" loop drawing lines for each star children
		//...Now how do we get what the 
=======
		print ("1");

>>>>>>> Caroline
		return true;
	}
	//----------------------------------------------------------//

	void DrawLineBetween (Vector3 start, Vector3 end, Color color)
	{
		print ("startLineDraw"); 
		GameObject myLine = new GameObject ();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer> ();
		LineRenderer lr = myLine.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.startColor = color;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
	}
}
