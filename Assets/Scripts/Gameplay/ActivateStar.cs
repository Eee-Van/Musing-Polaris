using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEditor;

public class ActivateStar : MonoBehaviour
{
	//Variables that help look up wether or not the star is active.
	public bool active;
	public float activeTimerSec = 30f;

	//Tracks Polaris + Temporary variable that helps with updating the star's timer
	private GameObject polaris;
	private float tempT;

	//The three states the star is susceptible of having.
	public GameObject untouched;
	public GameObject activated;
	public GameObject discovered;
	public AudioSource starAudioPlayer;
	public AudioClip discoverySound;
	public AudioClip activationSound;

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
		if (!GetComponentInParent<AreChildsActive> ().constDiscovered) { //Si la constellation n'est PAS découverte...
			if (active == true) {
				tempT -= Time.deltaTime;
				if (tempT < 0 && transform.parent.GetComponent<AreChildsActive> ().constDiscovered == false) { 
					//If the indivual star timer runs out, and the constellation is still undiscovered, then :
					active = false;
					tempT = 0;
				}
				if (!activated.activeSelf) {
					activated.SetActive (true);
					untouched.SetActive (false);
					discovered.SetActive (false);
					starAudioPlayer.PlayOneShot (activationSound);
				}
			} else if (!untouched.activeSelf) {
				activated.SetActive (false);
				untouched.SetActive (true);
				discovered.SetActive (false);
			}
		} else if (!discovered.activeSelf) {//Lorsque la constellation EST découverte...
			activated.SetActive (false);
			untouched.SetActive (false);
			discovered.SetActive (true);
			starAudioPlayer.PlayOneShot (discoverySound);
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
