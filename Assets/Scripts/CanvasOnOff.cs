using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOnOff : MonoBehaviour
{

	public Canvas canvas;

	//--------------------------START---------------------------//
	void Start ()
	{

	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (canvas.isActiveAndEnabled)
				canvas.gameObject.SetActive (false);
			else if (!canvas.isActiveAndEnabled) {
				canvas.gameObject.SetActive (true);
			}
		}
	}
	//----------------------------------------------------------//
}
