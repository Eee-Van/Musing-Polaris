using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarisScript: MonoBehaviour
{
	//Variables used to control the volume
	public float maxVolume = 0.25f;
	private AudioSource polarisAudioSource;
	private Rigidbody polarisRigidBody;

	void Start ()
	{
		polarisAudioSource = GetComponent<AudioSource> ();
		polarisRigidBody = GetComponent<Rigidbody> ();
		maxVolume = maxVolume * PlayerPrefs.GetFloat ("masterVolumePref") * 2;
	}

	void Update ()
	{
		polarisAudioSource.volume = -0.05f +
		(Mathf.Abs (polarisRigidBody.velocity.x) + Mathf.Abs (polarisRigidBody.velocity.y)) / (maxVolume);
		if (polarisAudioSource.volume > maxVolume) {
			polarisAudioSource.volume = maxVolume;
		}
	}
}
