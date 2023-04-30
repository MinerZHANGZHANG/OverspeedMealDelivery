using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour
{

	private bool m_isVisible=false;
	private Transform m_player;

	private void Start()
	{
		m_player = GameObject.FindWithTag("Player").transform;
		StartCoroutine(LookAt());
	}
	private void OnBecameVisible()
	{
		m_isVisible= true;
	}
	private void OnBecameInvisible()
	{
		m_isVisible= false;
	}

	IEnumerator LookAt()
	{
		while (true)
		{
			if (m_isVisible)
			{
				transform.DOLookAt(m_player.position, 0.5f);
			}
			yield return new WaitForSeconds(0.5f);			
		}
	}
}
