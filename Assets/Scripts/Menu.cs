using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{

	private float masterVolume;

	// Variables for the options menu
	public Slider masterVolumeSlider;
	public Toggle subtitlesToggle;

	// Blackscreen for fade in/fade out
	public GameObject blackScreen;
	//	public AnimationClip fadeIn;

	//--------------------------START---------------------------//
	void Start ()
	{
		//Mise à jour du volume si un paramètre de préférence existe
		if (PlayerPrefs.HasKey ("masterVolumePref")) {
			masterVolume = PlayerPrefs.GetFloat ("masterVolumePref");
			masterVolumeSlider.value = masterVolume;
		}
	}
	//----------------------------------------------------------//


	//-------------------------UPDATE---------------------------//
	void Update ()
	{
		
	}
	//----------------------------------------------------------//


	//----------------------VOLUME_UPDATE-----------------------//
	//Called whenever the Master Volume Slider changes value
	public void UpdateVolume ()
	{
		//masterVolumePref = Stockage du masterVolume préférentiel
		masterVolume = masterVolumeSlider.value;
		PlayerPrefs.SetFloat ("masterVolumePref", masterVolume);
	}
	//----------------------------------------------------------//

	//----------------------LAUNCH_GAME-------------------------//
	public void LaunchGame ()
	{
		blackScreen.GetComponent<Animation> ().Play ("FadeIn");
		StartCoroutine (GoToGame ());
	}
	//----------------------------------------------------------//


	//----------------------GOTO_GAME---------------------------//
	public IEnumerator GoToGame ()
	{
		yield return new WaitForSeconds (
			blackScreen.GetComponent<Animation> ().clip.length); //Lets the FadeIn animation play out
		SceneManager.LoadScene ("PlayTest");
		yield break;
	}
	//----------------------------------------------------------//


	//----------------------QUIT_GAME---------------------------//
	public void QuitGame ()
	{
		Debug.Log ("Game should exit");
		Application.Quit ();
	}
	//----------------------------------------------------------//


	//---------------------SUBTITLES_TOGGLE---------------------//
	//Called whenever the Subtitle Toggle changes value
	public void ToggleSubtitles ()
	{
		//This all just changes the text displayed next to the Toggle. Effectively does nothing.
		if (subtitlesToggle.isOn) {
			subtitlesToggle.GetComponentInChildren<TextMeshProUGUI> ().SetText ("...there is no dialog");
		} else {
			subtitlesToggle.GetComponentInChildren<TextMeshProUGUI> ().SetText ("Subtitles");
		}
	}
	//----------------------------------------------------------//


	//------------------------NAVIGATION------------------------//
	//Called when certain buttons are pressed (Return buttons, Options button, Compendum button)
	public void MenuNavigation (GameObject whereToGo)
	{
		foreach (Transform children in transform) {
			if (children.name == "ScreenMain" || /////
			    children.name == "ScreenOptions" ||	// Condition checks that only Screen Menu Groups get disabled
			    children.name == "ScreenAtlas") {	//
				children.gameObject.SetActive (false); //The menu deactivated itself before activating the target menu
			}
		}
		whereToGo.SetActive (true); //Target menu activates
	}
	//----------------------------------------------------------//

}
