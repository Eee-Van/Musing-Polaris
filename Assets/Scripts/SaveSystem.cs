using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	private GameObject polaris;

	public string myPath;

	//--------------------------START---------------------------//
	void Start ()
	{
		myPath = GetPath ();
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.gameObject;
	}
	//----------------------------------------------------------//


	//--------------------------SAVE----------------------------//
	public void Save ()
	{
		DataContainer myData = new DataContainer ();
		myData.polarisX = polaris.transform.position.x;
		myData.polarisY = polaris.transform.position.y;

		myData.Save (myPath);
	}
	//----------------------------------------------------------//


	//--------------------------LOAD----------------------------//
	public void Load ()
	{
		DataContainer myData = DataContainer.Load (myPath);
//		Polaris.transform.position.x = myData.polarisX;
//		Polaris.transform.position.y = myData.polarisY;

		polaris.transform.position = new Vector3 (myData.polarisX, myData.polarisY, polaris.transform.position.z);

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
