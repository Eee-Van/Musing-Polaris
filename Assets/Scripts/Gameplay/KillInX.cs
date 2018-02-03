using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillInX : MonoBehaviour
{
	//Variables
	public float X;

	//-------------------------START----------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//

	//------------------------UPDATE---------------------------//
	void Update ()
	{
		X -= Time.deltaTime;
		if (X < 0f) {
			Destroy (gameObject);
		}
	}
	//----------------------------------------------------------//
}
