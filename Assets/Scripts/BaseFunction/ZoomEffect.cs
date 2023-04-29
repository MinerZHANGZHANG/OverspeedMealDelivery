using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomEffect : MonoBehaviour,IPointerEnterHandler
{
	[Header("·Å´ó±¶ÂÊ")]
	[SerializeField]
	private float m_zoomSize = 1.2f;
	private Vector3 m_baseSize;

	private void OnEnable() => m_baseSize = transform.localScale;
	public void OnPointerEnter(PointerEventData eventData) => transform.localScale *= m_zoomSize;
	public void OnPointerExit(PointerEventData eventData) => transform.localScale = m_baseSize;
}
