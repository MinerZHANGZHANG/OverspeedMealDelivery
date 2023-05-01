using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Road : MonoBehaviour
{

	public int Index = 0;
	public UnityAction<int> OnPlayerEnter;
	public UnityAction<int> OnPlayerLeave;

	public Transform BuildParent;
	public Transform TreeParent;

	public List<GameObject> BuildingList = new();
	public List<GameObject> TreeList = new();
	public List<GameObject> CarList = new();

	public int MinBuilding = 4;
	public int MaxBuilding = 10;
	[Range(0f, 1f)]
	public float ClientGenerateRate = 0.8f;
	void Start()
	{
		GenerateNewThing();
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			OnPlayerEnter?.Invoke(Index);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			OnPlayerLeave?.Invoke(Index);
		}
	}

	public void ClearAllBuildAndClient()
	{
		StartCoroutine(LateDestory());
	}

	IEnumerator LateDestory()
	{
		for (int i = 0; i < BuildParent.childCount; i++)
		{
			Destroy(BuildParent.GetChild(i).gameObject, Random.value);
		}		
		for (int i = 0; i < TreeParent.childCount; i++)
		{
			Destroy(TreeParent.GetChild(i).gameObject, Random.value);
		}
		yield return null;
	}

	public void GenerateNewThing()
	{
		GenerateBuild();
		GenerateClient();
		GenerateTree();
		GenerateCar();

	}

	public void GenerateBuild()
	{
		StartCoroutine(LateLoadBuilding());
	}

	IEnumerator LateLoadBuilding()
	{
		int buildingNumber = Random.Range(MinBuilding, MaxBuilding + 1);
		float buildingInterval = 250 / buildingNumber;
		for (int i = 0; i < buildingNumber; i++)
		{
			var left = Random.value <= 0.5;
			var building = Instantiate(BuildingList[Random.Range(0, BuildingList.Count)]);
			building.transform.SetParent(BuildParent);
			yield return null;
			if (left)
			{
				building.transform.position = transform.position
				+ new Vector3(buildingInterval * i - 125, 0.5f, 36)
				+ new Vector3(Random.Range(5, buildingInterval - 5), 0, 0);
			}
			else
			{
				building.transform.SetPositionAndRotation(transform.position
				+ new Vector3(buildingInterval * i - 125, 0.5f, 14)
				+ new Vector3(Random.Range(5, buildingInterval - 5), 0, 0),
				Quaternion.Euler(0, 180, 0));
			}
			yield return null;
		}
	}

	IEnumerator LateLoadTree()
	{
		int treeNumber = Random.Range(MinBuilding, MaxBuilding + 1) * 5;
		float treeInterval = 250 / treeNumber;
		for (int i = 0; i < treeNumber; i++)
		{
			var left = Random.value <= 0.5;
			var building = Instantiate(TreeList[Random.Range(0, TreeList.Count)]);
			building.transform.SetParent(TreeParent);
			yield return null;
			if (left)
			{
				building.transform.position = transform.position
				+ new Vector3(treeInterval * i - 125, 0.5f, Random.Range(40, 50))
				+ new Vector3(Random.Range(5, treeInterval - 5), 0, 0);
			}
			else
			{
				building.transform.SetPositionAndRotation(transform.position
				+ new Vector3(treeInterval * i - 125, 0.5f, Random.Range(4, 12))
				+ new Vector3(Random.Range(5, treeInterval - 5), 0, 0),
				Quaternion.Euler(0, 180, 0));
			}
			yield return null;
		}
	}
	IEnumerator LateLoadClient()
	{
		yield return new WaitForSeconds(5f);
		for (int i = 0; i < BuildParent.childCount; i++)
		{
			var generateClients = GetComponentsInChildren<GenerateClient>();
			foreach (var item in generateClients)
			{

				item.GenerateNewClient(ClientGenerateRate);

				yield return null;
			}
			yield return null;
		}
	}

	IEnumerator LateLoadCar()
	{
		int carNumber = Random.Range(2,6);
		float carInterval = 250 / carNumber;
		for (int i = 0; i < carNumber; i++)
		{
			var forward = Random.value <= 0.5;

			var car = Instantiate(CarList[Random.Range(0, CarList.Count)]);		
			yield return null;

			if (forward)
			{
				car.transform.SetPositionAndRotation(transform.position
				+ new Vector3(carInterval * i - 125, 1f, 23f)
				,Quaternion.Euler(0, 180, 0));
				car.GetComponent<Car>().forward = Vector3.right;
			}
			else
			{
				car.transform.SetPositionAndRotation(transform.position
				+ new Vector3(carInterval * i - 125, 1f, 28)
				,Quaternion.Euler(0, 0, 0));
				car.GetComponent<Car>().forward = -Vector3.right;
			}
					
			yield return null;
		}
	}

	public void GenerateClient()
	{
		StartCoroutine(LateLoadClient());
	}

	public void GenerateTree()
	{
		StartCoroutine(LateLoadTree());
	}

	public void GenerateCar()
	{
		StartCoroutine(LateLoadCar());
	}




}
