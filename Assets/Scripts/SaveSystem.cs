using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	public GameObject Polaris;
	public string myPath;

	//--------------------------START---------------------------//
	void Start ()
	{
		myPath = GetPath ();
	}
	//----------------------------------------------------------//


	//--------------------------SAVE----------------------------//
	public void Save ()
	{
		DataContainer myData = new DataContainer ();
		myData.polarisX = Polaris.transform.position.x;
		myData.polarisY = Polaris.transform.position.y;

		myData.Save (myPath);
	}
	//----------------------------------------------------------//


	//--------------------------LOAD----------------------------//
	public void Load ()
	{
		DataContainer myData = DataContainer.Load (myPath);
//		Polaris.transform.position.x = myData.polarisX;
//		Polaris.transform.position.y = myData.polarisY;

		Polaris.transform.position = new Vector3 (myData.polarisX, myData.polarisY, Polaris.transform.position.z);

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
