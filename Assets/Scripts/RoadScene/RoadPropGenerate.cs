
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPropGenerate : MonoBehaviour
{
	[Header("Prop Generate")]
	public List<GameObject> PropList = new();
	public Transform PlayerTransfrom;
	public float PropGenerateInterval = 10f;

	private void Start()
	{
		StartCoroutine(TryGenerateProp());
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	IEnumerator TryGenerateProp()
	{
		while (true)
		{
			var newProp = Instantiate(PropList[Random.Range(0, PropList.Count)]);
			newProp.transform.position = PlayerTransfrom.position
				+ Vector3.right * Random.Range(30, 60)
				+ new Vector3(Random.Range(-5, 5), Random.Range(15, 30), Random.Range(-5, 5));
			;
			yield return new WaitForSeconds(PropGenerateInterval);
		}

	}
}
