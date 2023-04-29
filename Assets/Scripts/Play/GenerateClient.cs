using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GenerateClient : MonoBehaviour
{
	public GameObject OnGroundClientPrefab;
	public GameObject AtWindowClientPrefab;
	public enum ClientType
	{
		OnGround,
		AtWindow,
	}
	public ClientType Type;

	private const float m_generateCD= 30f;

	 public bool IsVisable=false;
	private float timer=-100f;

	private GameObject m_client;


	private void OnBecameVisible()=> IsVisable = true;
	private void OnBecameInvisible() => IsVisable = false;

	public bool GenerateNewClient() 
	{
		
		if (IsVisable && !m_client && (Time.realtimeSinceStartup - timer) > m_generateCD)
		{
			
			timer = m_generateCD;
			switch (Type)
			{
				case ClientType.OnGround:
					m_client = Instantiate(OnGroundClientPrefab,transform,true);
					break;
				case ClientType.AtWindow:
					m_client = Instantiate(AtWindowClientPrefab, transform, true);
					break;
				default:
					m_client = Instantiate(OnGroundClientPrefab, transform, true);
					Debug.LogError("error client type");
					break;
			}
			m_client.transform.position= transform.position;
			m_client.transform.rotation= transform.rotation;
			return true;
		}
		else
		{
			return false;
		}
	}
}
