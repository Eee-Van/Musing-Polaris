using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickControl : MonoBehaviour
{
	
	private Transform polaris;
	public GameObject parentStar;
	public float pullForce;

	public Color targetColor;
	public float colorLerpSpeed;

	private Color initParentColor;
	private bool pullActive;


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
	void pullPolaris (Rigidbody other)
	{
		Vector2 direction = new Vector3 (//Defines the direction from Polaris to the star
			                    transform.position.x - other.transform.position.x,
			                    transform.position.y - other.transform.position.y,
			                    0);
		other.AddForce (direction * pullForce, ForceMode.Force); //Pushes Polaris using the previous direction
		//Can vary the "pull" strength by varying pullForce


//		parentStar.GetComponent<SpriteRenderer> ().material.color = //Lerps the star's color over time			
//			Color.Lerp (targetColor, initParentColor, Mathf.PingPong (Time.time, colorLerpSpeed));
	}
	//--------------------------------------------------------//
}
