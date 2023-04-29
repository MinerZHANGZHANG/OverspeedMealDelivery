using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Takeway : MonoBehaviour
{
	public float LaunchThrust=10000f;
	public GameObject DeliveryEffectPrefab;
	public GameObject DisappearEffectPrefab;
	private bool m_isDisappearing=false;

	private void Start()
	{
		Destroy(gameObject,10f);
		GetComponent<Rigidbody>().AddForce(LaunchThrust * transform.forward);
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Client"))
		{
			m_isDisappearing = true;
			var effect= Instantiate(DeliveryEffectPrefab);
			effect.transform.position=transform.position;

			Destroy(collision.collider.gameObject);
			Destroy(gameObject);
		}
		else
		{
			if(!m_isDisappearing) 
			{ 
				m_isDisappearing = true;
				StartCoroutine(DestorySelf());
			}
			
		}
	}

	IEnumerator DestorySelf()
	{		
		yield return new WaitForSeconds(3f);
		transform.DOScale(0.1f, 1f);
		var effect = Instantiate(DisappearEffectPrefab);
		effect.transform.position = transform.position;
		yield return new WaitForSeconds(1.1f);
		Destroy(gameObject);
	}
}
