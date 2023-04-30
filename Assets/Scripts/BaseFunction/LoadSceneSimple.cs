using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneSimple : MonoBehaviour
{
	public Button LoadButton;
	public string SceneName;

	public void Start()
	{
		LoadButton.onClick.AddListener(()=>StartCoroutine(LoadScene()));
	}

	IEnumerator LoadScene()
	{
		Time.timeScale = 1.0f;
		LoadButton.interactable = false;
		LoadButton.transform.DOScale(transform.localScale*10,0.5f);
		yield return new WaitForSeconds(0.4f);
		SceneManager.LoadSceneAsync(SceneName);
	}
}
