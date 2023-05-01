using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionAudio : MonoBehaviour
{
	private AudioSource m_audioSource;
	private void Awake()
	{
		m_audioSource = GetComponent<AudioSource>();
		m_audioSource.playOnAwake = false;
	}
	private void OnCollisionEnter(Collision collision)
	{
		m_audioSource.Play();
	}
}
