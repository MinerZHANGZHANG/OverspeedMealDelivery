using System.Collections.Generic;
using UnityEngine;

public static class Tool 
{
	public static List<t> DisorderList<t>(this List<t> oldList)
	{
		List<t> newList = new List<t>();
		foreach (var item in oldList)
		{
			newList.Insert(Random.Range(0, newList.Count), item);
		}
		return (newList);
	}
}
