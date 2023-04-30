using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour
{
	public float mouseSensitivity = 100f;

	private float m_xRotation = 0f;
	private float m_yRotation = 0f;

    // Update is called once per frame
    void Update()
    {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


		m_xRotation -= mouseY;
		m_xRotation = Mathf.Clamp(m_xRotation, -70f, 30f);
		m_yRotation += mouseX;
		m_yRotation= Mathf.Clamp(m_yRotation, -45f, 45f);

		transform.localRotation = Quaternion.Euler(m_xRotation, m_yRotation, 0f);
		
	}
}
