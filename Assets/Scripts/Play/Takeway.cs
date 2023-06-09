using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Takeway : MonoBehaviour
{
	private AudioSource m_deliveryAudio;
	public GameObject DeliveryEffectPrefab;
	public GameObject DisappearEffectPrefab;
	private bool m_isDisappearing=false;

	private void Start()
	{
		Destroy(gameObject,10f);
		m_deliveryAudio=GameObject.FindGameObjectWithTag("DeliveryAudio").GetComponent<AudioSource>();
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Client"))
		{
			m_deliveryAudio.Play();
			m_isDisappearing = true;
			var effect= Instantiate(DeliveryEffectPrefab);
			effect.transform.position=transform.position;
			ScoreManager.AddScore(ScoreManager.ScoreSource.DeliveryFood, 80);			
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
		//var tweener= transform.DOScale(0.1f, 1f);
		var effect = Instantiate(DisappearEffectPrefab);
		effect.transform.position = transform.position;
		yield return new WaitForSeconds(1.1f);
		//tweener.Kill();
		ScoreManager.ReduceScore(ScoreManager.ScoreSource.LoseFood,2);
		Destroy(gameObject);
	}
}
