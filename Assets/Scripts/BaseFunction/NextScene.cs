using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public Button LoadButton;
    public CanvasGroup CanvasGroup;
    public string SceneName;

    public Transform CameraEndPoint;

	private void Start()
	{
        LoadButton.onClick.AddListener(delegate { StartCoroutine(LoadScene()); });
	}

	IEnumerator LoadScene()
    {
		
		Camera.main.transform.DOMove(CameraEndPoint.position, 1f);
        CanvasGroup.DOFade(0, 0.5f);
        yield return new WaitForSeconds(1.1f);
		SceneManager.LoadSceneAsync(SceneName);

	}

}
