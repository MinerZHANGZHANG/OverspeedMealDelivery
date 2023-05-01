using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public Button BackButton;
    public Button NextButton;

    public Image ShowImage;
    public List<Sprite> ImageList = new(5);
    private int m_imageCount=0;
    void Start()
    {
		ShowImage.sprite = ImageList[m_imageCount];
        NextButton.onClick.AddListener(NextImage);
        BackButton.onClick.AddListener(BackImage);
	}

    private void NextImage()
    {
        if (m_imageCount + 1 < ImageList.Count)
        {
            m_imageCount++;
            ShowImage.sprite= ImageList[m_imageCount];

            if (m_imageCount == ImageList.Count - 1)
            {
                NextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finish!";
                NextButton.onClick.AddListener(CloseSelf);
            }
        }
    }

    private void BackImage()
    {
        if (m_imageCount - 1 >= 0)
        {
			if (m_imageCount == ImageList.Count - 1)
			{
				NextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
				NextButton.onClick.RemoveListener(CloseSelf);
			}

			m_imageCount--;
			ShowImage.sprite = ImageList[m_imageCount];
		}
    }



    private void CloseSelf()
    {
        gameObject.SetActive(false);
    }
}
