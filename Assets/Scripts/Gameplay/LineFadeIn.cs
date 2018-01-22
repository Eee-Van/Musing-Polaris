using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFadeIn : MonoBehaviour
{
	private LineRenderer lr;
	private Color targetStartColor;
	private Color targetEndColor;
	private float timer = 0;

	//---------------------START-----------------------
	void Start ()
	{
		lr = GetComponent<LineRenderer> ();
	}
	//-------------------------------------------------

	//--------------------UPDATE-----------------------
	void Update ()
	{
		if (gameObject.activeSelf) {
			timer += Time.deltaTime;
			targetStartColor = new Color (lr.startColor.r, lr.startColor.g, lr.startColor.b,
				Mathf.Lerp (lr.startColor.a, 1, timer / 300));
			lr.startColor = targetStartColor;
			targetEndColor = new Color (lr.endColor.r, lr.endColor.g, lr.endColor.b,
				Mathf.Lerp (lr.endColor.a, 1, timer / 300));
			lr.endColor = targetEndColor;
		}
	}
	//-------------------------------------------------
}
