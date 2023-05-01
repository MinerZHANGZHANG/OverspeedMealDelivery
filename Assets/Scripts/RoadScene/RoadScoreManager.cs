using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Obsolete]
public class RoadScoreManager : MonoBehaviour
{
	public Transform TargetDeliveryPosiition;
	public Transform PlayerTransfrom;
	[Header("Game Info UI")]
	public TextMeshProUGUI ScoreText;
	public TextMeshProUGUI TimeText;
	public TextMeshProUGUI DeliveryTargetText;
	public GameObject WinMenu;

	public static int CurrentScore = 0;
	public static int DeliveryCount = 0;
	public static int LoseCount = 0;
	public static int GetPropCount = 0;

	public static UnityAction<int> OnScoreChanged;
	public static UnityAction<int> OnDeliveryCountChanged;

	public static float Timer = 0;
	public enum ScoreSource
	{
		DeliveryFood,
		LoseFood,
		GetProp,
		Remainder,
	}

	public static void AddScore(ScoreSource source, int value)
	{
		switch (source)
		{
			case ScoreSource.DeliveryFood:
				DeliveryCount++;
				OnDeliveryCountChanged?.Invoke(DeliveryCount);
				break;
			case ScoreSource.GetProp:
				GetPropCount++;
				break;
			case ScoreSource.Remainder:
				break;
			default:
				break;
		}

		CurrentScore += value;
		OnScoreChanged?.Invoke(CurrentScore);
	}

	public static void ReduceScore(ScoreSource source, int value)
	{
		switch (source)
		{
			case ScoreSource.DeliveryFood:

				break;
			case ScoreSource.LoseFood:
				LoseCount++;
				break;
			case ScoreSource.Remainder:
				break;
			default:
				break;
		}

		CurrentScore -= value;
		OnScoreChanged?.Invoke(CurrentScore);
	}

	private void OverGame()
	{
		PauseGame.IsPause = true;
		WinMenu.SetActive(true);		
	}

	void Start()
	{
		CurrentScore = 0;
		DeliveryCount = 0;
		LoseCount = 0;
		GetPropCount = 0;
		Timer = 0;

		OnScoreChanged = delegate { };
		OnDeliveryCountChanged = delegate { };

		OnScoreChanged += (score) => ScoreText.text = score.ToString();
		OnScoreChanged?.Invoke(0);
	}

	// Update is called once per frame
	void Update()
	{
		Timer += Time.deltaTime;
		TimeText.text = Timer.ToString("#");

		var distance = Vector3.Distance(transform.position, TargetDeliveryPosiition.position);
		DeliveryTargetText.text = $"¡¤Target Distance:{distance:#}";
		
		if (distance <= 10&&!PauseGame.IsPause)
		{
			OverGame();
		}
		
	}
}
