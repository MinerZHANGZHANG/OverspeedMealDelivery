using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnterPlayAudio : MonoBehaviour,IPointerEnterHandler
{
	public AudioSource AudioSource;
	public void OnPointerEnter(PointerEventData eventData)
	{
		AudioSource.Play();
	}
}
