using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> RoadList = new(4);

    public float SingleRoadLength = 250;
    void Start()
    {
        SetRoadIndex();
        foreach (var item in RoadList)
        {
            item.GetComponent<Road>().OnPlayerEnter += (index) =>
            {
                if (index == 2)
                {
                    SwapRoad();
                }
            };
        }
    }

    private void SwapRoad()
    {
        Road road0 = RoadList[0].GetComponent<Road>();
        Road road3 = RoadList[3].GetComponent<Road>();

		road0.gameObject.transform.position = road3.transform.position + Vector3.right * SingleRoadLength;
		road0.ClearAllBuildAndClient();

        road0.GenerateNewThing();

		RoadList.Remove(road0.gameObject);
		RoadList.Add(road0.gameObject);
		RoadList.TrimExcess();

		SetRoadIndex();
	}

    private void SetRoadIndex()
    {
		for (int i = 0; i < RoadList.Count; i++)
		{
            RoadList[i].GetComponent<Road>().Index = i;
		}
	}
}
