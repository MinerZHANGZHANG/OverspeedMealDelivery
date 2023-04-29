using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public float AdvanceForce = 2000f;
    public float RotateForce = 10f;
    private Rigidbody m_rigidbody;
    void Start()
    {
        m_rigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(Input.GetKey(KeyCode.W))
            {
                m_rigidbody.AddForce(AdvanceForce*Time.deltaTime*transform.forward);
            }
			if (Input.GetKey(KeyCode.S))
            {
				m_rigidbody.AddForce(AdvanceForce* Time.deltaTime * -transform.forward);
			}
            if(Input.GetKey(KeyCode.A)) 
            {
				if (true)
				{
					transform.Rotate(RotateForce* Mathf.Sqrt(m_rigidbody.velocity.magnitude) * Time.deltaTime * -transform.up);
                    m_rigidbody.velocity -= Time.deltaTime*0.2f * m_rigidbody.velocity;
				}

			}
			if (Input.GetKey(KeyCode.D))
			{
                if (true)
                {
					transform.Rotate(RotateForce * Mathf.Sqrt(m_rigidbody.velocity.magnitude) * Time.deltaTime * transform.up);
					m_rigidbody.velocity -= Time.deltaTime * 0.2f * m_rigidbody.velocity;
				}
			}
		}
    }
}
