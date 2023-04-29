using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
	public List<Texture2D> SkinTextures;

	private SkinnedMeshRenderer[] m_skinnedMeshRenderersInChildren;

	private void Awake()
	{
		m_skinnedMeshRenderersInChildren = GetComponentsInChildren<SkinnedMeshRenderer>();
		var randomTexture = SkinTextures[Random.Range(0,SkinTextures.Count)];
		foreach (var item in m_skinnedMeshRenderersInChildren)
		{
			item.material.mainTexture= randomTexture;
		}

		tag = "Client";
	}

	private void OnDestroy()
	{
		ScoreManager.AddScore(ScoreManager.ScoreSource.DeliveryFood, 100);
		GenerateManager.ClientCount--;
		foreach (var item in m_skinnedMeshRenderersInChildren)
		{
			Destroy(item.material);
		}
	}
}
