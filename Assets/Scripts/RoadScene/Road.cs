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
    public Transform ClientParent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }

    public void GenerateNewThing()
    {
        GenerateBuild();
        GenerateClient();
    }

    public void GenerateBuild()
    {

    }
    public void GenerateClient()
    {

    }
}
