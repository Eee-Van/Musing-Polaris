using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickControl : MonoBehaviour
{
	//Select the gameObject meant to appear when

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
	public AudioClip onClickSound;
	public AudioSource audioSource;
	public float pitchRange;

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
		Debug.Log (1);
		GetComponent<ParticleSystem> ().Play ();
		GetComponent<ParticleSystem> ().Emit (1);
		pullActive = true; //While true, Polaris is pulled
		audioSource.pitch = 1 + Random.Range (-1f, 1f)/pitchRange;
		audioSource.PlayOneShot (onClickSound, 1f);
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
