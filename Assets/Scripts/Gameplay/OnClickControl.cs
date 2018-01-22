using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickControl : MonoBehaviour
{
	//Variables used to control the movement of Polaris
	private Transform polaris;
	public GameObject parentStar;
	public float pullForce;
	private bool pullActive;

	//Variables used to control the (out of date) material color lerp
	//	public Color targetColor;
	//	public float colorLerpSpeed;
	//	private Color initParentColor;

	//Variables used to control the sounds emitted
	public AudioClip[] onClickSounds;
	public AudioSource audioSource;

	//--------------------------START---------------------------//
	void Start ()
	{
//		initParentColor = parentStar.GetComponent<SpriteRenderer> ().material.color;
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris;
	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{

	}
	//----------------------------------------------------------//


	//----------------------FIXED_UPDATE-----------------------//
	void FixedUpdate ()
	{
		// Application de la force sur Polaris
		if (pullActive == true) {
			pullPolaris (polaris.GetComponent<Rigidbody> ());
		}
		//
	}
	//----------------------------------------------------------//


	//----------------------ON_MOUSE_DOWN-----------------------//
	void OnMouseDown ()
	{
		pullActive = true; //While true, Polaris is pulled
		audioSource.pitch += Random.Range (-1, 1) / 25;
		audioSource.PlayOneShot (onClickSounds [Random.Range (0, onClickSounds.Length)], 1f);
	}
	//----------------------------------------------------------//


	//----------------------ON_MOUSE_UP-----------------------//
	void OnMouseUp ()
	{
		pullActive = false; //While false, Polaris is... not pulled
//		parentStar.GetComponent<SpriteRenderer> ().material.color = initParentColor;
	}
	//--------------------------------------------------------//


	//---------------------PULL_POLARIS----------------------//
	void pullPolaris (Rigidbody polarisRB)
	{
//		Système dépendant de la distance entre l'étoile et Polaris :
		Vector3 direction = new Vector3 (//Defines the direction from Polaris to the star
			                    (transform.position.x - polarisRB.transform.position.x),
			                    (transform.position.y - polarisRB.transform.position.y));
		polarisRB.AddForce ((direction.normalized) * pullForce, ForceMode.Force); //Pushes Polaris using the previous direction
		//Can vary the "pull" strength by varying pullForce
		//Puttin .normalized after direction makes the whole thing independent of DISTANCES

		//Have to rework this part. It does nothing right now.
//		parentStar.GetComponent<SpriteRenderer> ().material.color = //Lerps the star's color over time			
//			Color.Lerp (targetColor, initParentColor, Mathf.PingPong (Time.time, colorLerpSpeed));
	}
	//--------------------------------------------------------//
}
