using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
	[Header("Client Generate")]
	public List<GameObject> ClientGeneratePositionList = new();
	public List<GenerateClient> GenerateClientList = new();
	public string PosTag = "ClientPosition";

	public float ClientGenerateInterval = 2f;
	public int MaxClient = 40;
	public static int ClientCount = 0;

	[Header("Prop Generate")]
	public List<GameObject> PropList= new();
	private Transform PlayerTransfrom;
	public float PropGenerateInterval = 10f;

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
		ClientCount = 0;
		ClientGeneratePositionList =ClientGeneratePositionList.DisorderList();
		GenerateClientList=GenerateClientList.DisorderList();
		PlayerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;

		StartCoroutine(TryGenerateClient());
		StartCoroutine(TryGenerateProp());
		
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
			yield return new WaitForSeconds(ClientGenerateInterval);
		}
        
    }

	IEnumerator TryGenerateProp()
	{
		while (true)
		{
			var newProp = Instantiate(PropList[Random.Range(0, PropList.Count)]);
			newProp.transform.position=PlayerTransfrom.position
				+PlayerTransfrom.forward*Random.Range(10,30)
				+new Vector3(Random.Range(-5,5),Random.Range(15,30),Random.Range(-5,5));
				;
			yield return new WaitForSeconds(PropGenerateInterval);
		}

	}



}
