using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static bool IsPause = false;

    public GameObject PauseMenu;

    public Button PauseButton;
    public Button BackButton;

    private UnityAction m_inputESC;
    void Start()
    {
        IsPause = false;
        m_inputESC += delegate
        {
            if (IsPause&& PauseMenu.activeInHierarchy)
            {
                Back();
            }
            else if(!IsPause&&!PauseMenu.activeInHierarchy)
            {
                Pause();
            }
        };

        PauseButton.onClick.AddListener(Pause);
        BackButton.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { m_inputESC?.Invoke(); }
    }

    private void Pause()
    {
        IsPause = true;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    private void Back()
    {
		IsPause = false;
		Time.timeScale = 1.0f;
		PauseMenu.SetActive(false);
	}
}
