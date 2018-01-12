using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStar : MonoBehaviour
{
	public bool active;
	public float activeTimerSec = 300f;

	private GameObject polaris;
	private float tempT;

	//--------------------------START---------------------------//
	void Start ()
	{
		active = false; //Stars are inactive by default
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.gameObject; //Gets Polaris from MainCamera
	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
		if (active == true) {
			tempT -= Time.deltaTime;
			if (tempT < 0 && transform.parent.GetComponent<AreChildsActive> ().constDiscovered == false) { 
				//If the indivual star timer runs out, and the constellation is still undiscovered, then :
				active = false;
				tempT = 0;
			}
		}
	}
	//----------------------------------------------------------//


	//---------------------ON_TRIGGER_ENTER--------------------//
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == polaris) {
			active = true;
			tempT = activeTimerSec;
		}
	}
	//----------------------------------------------------------//


	//----------------------ON_MOUSE_DOWN-----------------------//
	void OnMouseDown ()
	{
		
	}
	//----------------------------------------------------------//
}
