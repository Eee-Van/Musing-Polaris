using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUIOnOff : MonoBehaviour
{

	public GameObject saveUI;

	//--------------------------START---------------------------//
	void Start ()
	{

	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (saveUI.activeInHierarchy)
				saveUI.SetActive (false);
			else if (!saveUI.activeInHierarchy) {
				saveUI.SetActive (true);
			}
		}
	}
	//----------------------------------------------------------//
}
