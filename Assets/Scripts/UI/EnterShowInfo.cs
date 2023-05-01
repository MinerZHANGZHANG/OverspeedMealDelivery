using UnityEngine;
using UnityEngine.EventSystems;

public class EnterShowInfo : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
	public GameObject InfoGameObject;
	public void OnPointerEnter(PointerEventData eventData)
	{
		InfoGameObject.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		InfoGameObject.SetActive(false);
	}

	void Start()
    {
		InfoGameObject.SetActive(false);
    }
}
