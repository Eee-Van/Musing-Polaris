using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOnOff : MonoBehaviour
{

	public GameObject loadSaveUI;



	//--------------------------START---------------------------//
	void Start ()
	{

	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (loadSaveUI.activeSelf)
				loadSaveUI.gameObject.SetActive (false);
			else if (!loadSaveUI.activeSelf) {
				loadSaveUI.gameObject.SetActive (true);
			}
		}
	}
	//----------------------------------------------------------//
}
