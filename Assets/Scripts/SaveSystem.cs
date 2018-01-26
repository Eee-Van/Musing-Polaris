using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	private GameObject polaris;
	private float tempFloatX;
	private float tempFloatY;

	//--------------------------START---------------------------//
	void Start ()
	{
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.gameObject;
	}
	//----------------------------------------------------------//


	//--------------------------SAVE----------------------------//
	public void Save ()
	{
		PlayerPrefs.SetFloat ("polarisPosX", polaris.transform.position.x);
		PlayerPrefs.SetFloat ("polarisPosY", polaris.transform.position.y);
	}
	//----------------------------------------------------------//


	//--------------------------LOAD----------------------------//
	public void Load ()
	{
		if (PlayerPrefs.HasKey ("polarisPosX") && PlayerPrefs.HasKey ("polarisPosY")) {
			polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.gameObject;
			tempFloatX = PlayerPrefs.GetFloat ("polarisPosX");
			tempFloatY = PlayerPrefs.GetFloat ("polarisPosY");
//			polaris.transform.position = new Vector3 (tempFloatX, tempFloatY, 0);
		}
	}
	//----------------------------------------------------------//
}
