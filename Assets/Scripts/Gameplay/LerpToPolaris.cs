using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPolaris : MonoBehaviour
{

	public float lerpSpeed = 1f;
	public Transform polaris;

	//--------------------------START---------------------------//
	void Start ()
	{
		
	}
	//----------------------------------------------------------//


	//----------------------FIXED_UPDATE-----------------------//
	void FixedUpdate ()
	{
		Vector2 pos = Vector2.Lerp ((Vector2)transform.position,
			              (Vector2)polaris.position, (Time.fixedDeltaTime * lerpSpeed) / 4);
		transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
	}
	//----------------------------------------------------------//
}
