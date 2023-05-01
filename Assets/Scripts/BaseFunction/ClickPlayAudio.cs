using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPlayAudio : MonoBehaviour,IPointerClickHandler
{
	public AudioSource AudioSource;
	public void OnPointerClick(PointerEventData eventData)
	{
		AudioSource.Play();
	}

}
