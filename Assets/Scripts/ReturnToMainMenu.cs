using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
	//Variables qui gèrent la fermeture du jeu et le fade to black
	public float fadespeed = 1;
	public Image blackScreen;
	private float holdTimer;

	//Variable pour sauvegarder la position du joueur lorsqu'il quitte le jeu
	private GameObject polaris;
	public GameObject saveManagerObject;

	//-------------------------START----------------------------//
	void Start ()
	{
		polaris = Camera.main.GetComponent<LerpToPolaris> ().polaris.gameObject;
	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
		//This part makes the holdTimer variable fluctuate, which dictates other things.
		if (Input.GetKey (KeyCode.Escape)) {
			holdTimer += Time.deltaTime * fadespeed / 2f;
			if (holdTimer > 1) {
				holdTimer = 1;
			}
		} else if (holdTimer >= 0) {
			holdTimer -= Time.deltaTime * fadespeed * 2f;
			if (holdTimer < 0) {
				holdTimer = 0;
			}
		} 
		//End of holdTimer manipulation

		blackScreen.color = new Color (0, 0, 0, holdTimer); //Darkens the screen when the player is leaving

		if (holdTimer == 1) {
			SceneManager.LoadScene ("MainMenu");
			saveManagerObject.GetComponent<SaveSystem> ().Save ();
		}
	}
	//----------------------------------------------------------//
		
}
