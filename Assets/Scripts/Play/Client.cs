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

		Invoke(nameof(SetToGround), 0.1f);
		tag = "Client";
		//Debug.Log(transform.position);
	}


	private void SetToGround()
	{
		if (transform.parent.GetComponent<GenerateClient>().Type == GenerateClient.ClientType.OnGround)
		{
			//Debug.Log(transform.position);
			//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000f, Color.red, 1000f);
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit raycastHit, 100f))
			{
				transform.position = raycastHit.point - Vector3.up * 0.1f;
				//Debug.Log($"new position:{transform.position}");
			}
		}
	}

	private void OnDestroy()
	{

		GenerateManager.ClientCount--;
		foreach (var item in m_skinnedMeshRenderersInChildren)
		{
			Destroy(item.material);
		}
	}
}
