using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	public GameObject Polaris;
	public string myPath;

	private float tempFloatX;
	private float tempFloatY;

	//--------------------------START---------------------------//
	void Start ()
	{
		myPath = GetPath ();
		Polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.gameObject;
	}
	//----------------------------------------------------------//


	//--------------------------SAVE----------------------------//
	public void Save ()
	{
		PlayerPrefs.SetFloat ("polarisPosX", Polaris.transform.position.x);
		PlayerPrefs.SetFloat ("polarisPosY", Polaris.transform.position.y);
	}
	//----------------------------------------------------------//


	//--------------------------LOAD----------------------------//
	public void Load ()
	{
		if (PlayerPrefs.HasKey ("polarisPosX") && PlayerPrefs.HasKey ("polarisPosY")) {
			tempFloatX = PlayerPrefs.GetFloat ("polarisPosX");
			tempFloatY = PlayerPrefs.GetFloat ("polarisPosY");
			Polaris.transform.position = new Vector3 (tempFloatX, tempFloatY, 0);
		}
	}
	//----------------------------------------------------------//


	//-------------------------GET_PATH-------------------------//
	public string GetPath ()
	{
		string TempPath = Directory.GetCurrentDirectory ();

		if (!Directory.Exists (TempPath + @"\Data")) {
			Directory.CreateDirectory (TempPath + @"\Data");
		}

		TempPath += @"\Data\LevelData.xml";

		return TempPath;
	}
	//----------------------------------------------------------//
}
