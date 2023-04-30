using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
	public TextMeshProUGUI ScoreText;
	public TextMeshProUGUI TimeText;
	public TextMeshProUGUI PropText;
	private void OnEnable()
	{
		ScoreText.text = $"Score:{(int)(ScoreManager.CurrentScore+ Mathf.Clamp(300 - ScoreManager.Timer, 0, 300))}";
		TimeText.text = $"Time:{ScoreManager.Timer:#.##}";
		PropText.text = $"Get Prop:{ScoreManager.GetPropCount}";
	}

	
}
