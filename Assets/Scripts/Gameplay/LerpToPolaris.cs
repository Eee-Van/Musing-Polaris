using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPolaris : MonoBehaviour
{
	//Those are public variable that are stored here so that they are easily accessible from any script
	public string currentConst;
	public Transform polaris;

	//Those are variables used locally
	public float lerpSpeed = 1f;
	public Transform lerpTarget;

	//--------------------------START---------------------------//
	void Start ()
	{
		transform.position = new Vector3 (polaris.position.x, polaris.position.y, transform.position.z);
	}
	//----------------------------------------------------------//


	//----------------------FIXED_UPDATE-----------------------//
	void FixedUpdate ()
	{
		Vector2 pos = Vector2.Lerp ((Vector2)transform.position,
			              (Vector2)lerpTarget.position, (Time.fixedDeltaTime * lerpSpeed) / 4);
		transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
	}
	//----------------------------------------------------------//
}
