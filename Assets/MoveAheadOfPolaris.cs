using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAheadOfPolaris : MonoBehaviour
{

	private Rigidbody polaris;
	private Vector3 dummyTarget;

	void Start ()
	{
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		transform.position = new Vector3 (transform.position.x + polaris.velocity.x,
			transform.position.y + polaris.velocity.y,
			transform.position.z);
	}
}
