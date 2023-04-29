using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{

	public List<GameObject> ClientGeneratePositionList = new();
	public List<GenerateClient> GenerateClientList = new();
	public string PosTag = "ClientPosition";

	public float GenerateInterval = 2f;
	public int MaxClient = 40;
	public static int ClientCount = 0;

    [ContextMenu("Add Generate Position")]
    public void FindCurrentAllClientPos()
    {
		ClientGeneratePositionList.Clear();
		GenerateClientList.Clear();

		ClientGeneratePositionList.AddRange(GameObject.FindGameObjectsWithTag(PosTag));
        ClientGeneratePositionList.ForEach(go=>GenerateClientList.Add(go.GetComponent<GenerateClient>()));
    }

	private void Start()
	{
        StartCoroutine(TryGenerateClient());
	}

	IEnumerator TryGenerateClient()
    {
        while (true)
        {
			if (ClientCount < MaxClient)
			{
				foreach (var item in GenerateClientList)
				{
					if (item.IsVisable && item.GenerateNewClient())
					{
						break;
					}
				}
			}		
			yield return new WaitForSeconds(GenerateInterval);
		}
        
    }
}
