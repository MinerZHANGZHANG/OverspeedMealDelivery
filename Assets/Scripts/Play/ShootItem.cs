using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class ShootItem : MonoBehaviour
{
    public AudioSource ShootAudio;
    public AudioSource GetPropAudio;
    public LayerMask LayerMask;

    public List<GameObject> ItemList = new();

    public Texture2D AimCursor;
    public Texture2D ShootCursor;
    public Texture2D GetCursor;
    public Texture2D PauseCursor;

	public Scrollbar EnergyScrollbar;
    public Image ScrollbarHandleImage;
    public float MaxLaunchThrust=4000f;
    public float StorageSpeed=1f;

	private Vector3 m_position;

    private Tweener m_tweener;
    private LineRenderer m_lineRenderer;
    private void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.enabled = false;
		m_tweener = EnergyScrollbar.GetComponent<RectTransform>().DOShakeScale(65535,0.2f,2);
        m_tweener.Pause();
    }

	// Update is called once per frame
	void Update()
    {
        if (PauseGame.IsPause)
        {
			Vector2 offset = new(PauseCursor.width / 2, PauseCursor.height / 2);
			Cursor.SetCursor(PauseCursor, offset, CursorMode.Auto);
			return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hit, LayerMask))
		{
			m_position = hit.point;
			if (hit.collider.CompareTag("Client"))
			{
                Vector2 offset=new(ShootCursor.width/2 ,ShootCursor.height/2);
				Cursor.SetCursor(ShootCursor, offset, CursorMode.Auto);
			}
			else if (hit.collider.CompareTag("Prop"))
			{
				Vector2 offset = new(GetCursor.width / 2, GetCursor.height / 2);
				Cursor.SetCursor(GetCursor, offset, CursorMode.Auto);
				GetProp(hit.collider.gameObject);
			}
			else
			{
				Vector2 offset = new(AimCursor.width / 2, AimCursor.height / 2);
				Cursor.SetCursor(AimCursor, offset, CursorMode.Auto);
			}

		}
		else
		{
			m_position = ray.GetPoint(1000f);
		}

		if (Input.GetKey(KeyCode.Mouse0))
        {
			EnergyScrollbar.size=Mathf.Clamp01(EnergyScrollbar.size + StorageSpeed * Time.deltaTime);
            ScrollbarHandleImage.color = new(1, 1 - EnergyScrollbar.size, 0);

        }
		if (EnergyScrollbar.size >= 0.9 && !m_tweener.IsPlaying())
		{
			m_tweener.Play();
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{           
			ShootRandomItem(m_position);
		}

		if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void ShootRandomItem(Vector3 position)
    {
        ShootAudio.Play();
        var bullet = Instantiate(ItemList[Random.Range(0, ItemList.Count)]);
        bullet.transform.position = transform.position;
        bullet.transform.LookAt(position);
		bullet.GetComponent<Rigidbody>().AddForce(MaxLaunchThrust*(0.1f+EnergyScrollbar.size) * bullet.transform.forward);
        EnergyScrollbar.size = 0f;
        if (m_tweener.IsPlaying())
        {
			m_tweener.Pause();
		}
		
	}

    void GetProp(GameObject prop)
    {
        GetPropAudio.Play();
        prop.tag = "Untagged";

        m_lineRenderer.enabled = true;
        m_lineRenderer.SetPosition(0,transform.position);
        m_lineRenderer.SetPosition(1,prop.transform.position);

        StartCoroutine(MoveToSelf(prop));
    }

    IEnumerator MoveToSelf(GameObject item)
    {
        float speed = 5f;
        while (Vector3.Distance(item.transform.position, transform.position) >= 1)
        {
            item.transform.LookAt(transform);
            item.transform.Translate(speed * Time.deltaTime * Vector3.forward, Space.Self);
			m_lineRenderer.SetPosition(1, item.transform.position);
            speed += 3f*Time.deltaTime;
			yield return null;
        }
		m_lineRenderer.enabled = false;
        item.GetComponent<Prop>().TriggerEffect();
		Destroy(item);
    }

    public void KeepMaxEnergyStorage()
    {
        StartCoroutine(KeepEnegry());
    }

    IEnumerator KeepEnegry()
    {
        float timer = 0;
        while (timer <= 10f)
        {
            timer+= Time.deltaTime;
            EnergyScrollbar.size = 1.0f;
			yield return null;
        }
		
	}
}
