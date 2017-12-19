using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
	public float zoomDelay = 3f;
	public float zoomIncrement = 33f;

	public float maxZoomOut = -20f;
	public float minZoomIn = -5f;

	public Camera Cam;

	private float targetCamZ;

	void Start ()
	{
		targetCamZ = minZoomIn;
	}

	void Update ()
	{
		//Zoom in or out en utilisant l'output envoyée par l'input "Mouse ScrollWheel"
		targetCamZ += Input.GetAxis ("Mouse ScrollWheel") * zoomIncrement;

		//Limitations minimales et maximales du zoom (Inversé, car la cam est placé du côté négatif de l'axe)
		if (targetCamZ > minZoomIn) {
			targetCamZ = minZoomIn;
		}
		if (targetCamZ < maxZoomOut) {
			targetCamZ = maxZoomOut;
		}

		//Lerp de la position de la caméra actuelle vers la positioncible
		Vector3 targetCamPos = Camera.main.transform.position;
		targetCamPos.z = targetCamZ;
		Camera.main.GetComponent<Transform> ().position = Vector3.Lerp (Camera.main.transform.position, targetCamPos, 1 / zoomDelay);

	}
}