using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPreLinks : MonoBehaviour
{
	//This is all stuff related to how and where to draw the starlinks
	private GameObject[] linkedStars;
	public GameObject linePrefab;

	private GameObject parentConstellation;
	private Color linksColor;
	private float linkAlpha = 0f;

	//--------------------------START---------------------------//
	void Start ()
	{
		linkedStars = GetComponent<DrawLinks> ().linkedStars;
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
		if (gameObject.activeSelf && linkAlpha < 1) {
			linkAlpha += Time.deltaTime / 100;
		}
	}
	//----------------------------------------------------------//


	//---------------DRAW_LINE_BETWEEN_TWO_POINTS---------------//
	void DrawLineBetween (Vector3 start, Vector3 end, Color color)
	{
		print ("startLineDraw"); 
		GameObject myLine = Instantiate (linePrefab);
		myLine.transform.position = start;
		LineRenderer lr = myLine.GetComponent<LineRenderer> ();
		lr.startColor = new Color (color.r / 3, color.g / 3, color.b / 3, 0);
		lr.endColor = new Color (color.r / 3, color.g / 3, color.b / 3, 0);
		lr.startWidth = 0.1f;
		lr.endWidth = 0.1f;
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
	}
	//----------------------------------------------------------//
}
