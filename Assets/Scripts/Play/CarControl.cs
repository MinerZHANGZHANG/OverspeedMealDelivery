using System.Collections;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public AudioSource RunAudioSource;
    public float AdvanceForce = 2000f;
    public float RotateForce = 10f;
    private Rigidbody m_rigidbody;
    private float m_baseForce;
    void Start()
    {
        m_baseForce = AdvanceForce;
        m_rigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseGame.IsPause) return;
        if(Input.anyKey)
        {
            if(Input.GetKey(KeyCode.W))
            {
				RunAudioSource.Play();
				m_rigidbody.AddForce(AdvanceForce*Time.deltaTime*transform.forward);
            }
			if (Input.GetKey(KeyCode.S))
            {
				RunAudioSource.Play();
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

    public void CarSpeedUp()
    {
        StartCoroutine(UpSpeed());
    }

    IEnumerator UpSpeed()
    {
        AdvanceForce += 1000f;
        while (Camera.main.fieldOfView < 75)
        {
            Camera.main.fieldOfView += Time.deltaTime * 15f;
            yield return null;
                
		}     
        yield return new WaitForSeconds(13f);
		while (Camera.main.fieldOfView > 60)
		{
			Camera.main.fieldOfView -= Time.deltaTime * 10f;
			yield return null;

		}
		AdvanceForce -= 1000f;
    }
}
