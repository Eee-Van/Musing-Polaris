using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreChildsActive : MonoBehaviour
{
	public Color constColor;

	public bool constDiscovered;
	public GameObject[] starChildren;


	//--------------------------START---------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//


	//--------------------------UPDATE--------------------------//
	void Update ()
	{
		if (constDiscovered == false) {
			if (CheckIfStarsAreActive ())
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
		//Here there should be a "for" loop drawing lines for each star children
		//...Now how do we get what the 
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
