using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using UnityEngine;
using TMPro;

public class DataContainer
{

	public float polarisX;
	public float polarisY;
	public List<bool> completedConstellations;

	public TextMeshProUGUI text;

	//--------------------------START---------------------------//
	void Start ()
	{

	}
	//----------------------------------------------------------//


	//--------------------------SAVE----------------------------//
	public void Save (string thisPath)
	{
		var serializer = new XmlSerializer (typeof(DataContainer));

		var encoding = Encoding.GetEncoding ("UTF-8");

		using (StreamWriter stream = new StreamWriter (thisPath, false, encoding)) {
			serializer.Serialize (stream, this);
		}
	}
	//----------------------------------------------------------//


	//--------------------------LOAD----------------------------//
	public static DataContainer Load (string thisPath)
	{
		var serializer = new XmlSerializer (typeof(DataContainer));

		using (var stream = new FileStream (thisPath, FileMode.Open)) {
			return serializer.Deserialize (stream) as DataContainer;
		}
	}
	//----------------------------------------------------------//
}
