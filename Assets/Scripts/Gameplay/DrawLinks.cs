using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinks : MonoBehaviour
{

	public GameObject[] linkedStars;
	public GameObject linePrefab;

	private GameObject parentConstellation;
	private Color linksColor;

	//--------------------------START---------------------------//
	void Start ()
	{
		parentConstellation = gameObject.GetComponentInParent<AreChildsActive> ().gameObject;
		linksColor = parentConstellation.GetComponent<AreChildsActive> ().constColor;

		for (int i = 0; i < linkedStars.Length; i++) {
			DrawLineBetween (transform.position, linkedStars [i].transform.position, linksColor);
		}
	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
//		print (linksColor);
	}
	//----------------------------------------------------------//


	//---------------DRAW_LINE_BETWEEN_TWO_POINTS---------------//
	void DrawLineBetween (Vector3 start, Vector3 end, Color color)
	{
		print ("startLineDraw"); 
		GameObject myLine = Instantiate (linePrefab);
		myLine.transform.position = start;
		LineRenderer lr = myLine.GetComponent<LineRenderer> ();
		lr.startColor = color;
		lr.endColor = color;
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
	}
	//----------------------------------------------------------//
}
