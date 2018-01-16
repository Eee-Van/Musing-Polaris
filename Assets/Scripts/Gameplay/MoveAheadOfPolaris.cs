using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAheadOfPolaris : MonoBehaviour
{
	private Rigidbody polaris;
	private Vector3 dummyTarget;

	//--------------------------START--------------------------//
	void Start ()
	{
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.GetComponent<Rigidbody> ();
	}
	//---------------------------------------------------------//

	//--------------------------UPDATE--------------------------//
	void Update ()
	{
		transform.position = new Vector3 (polaris.transform.position.x + polaris.velocity.x * 2,
			polaris.transform.position.y + polaris.velocity.y * 2,
			0);
	}
	//----------------------------------------------------------//

}
