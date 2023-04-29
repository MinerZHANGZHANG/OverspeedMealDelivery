using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    private Vector3 m_initialPosition;
    private Vector3 m_targetPosition;

    public float Amplitude=2f;
    public float Frequency = 1f;
    void Start()
    {
        m_initialPosition = transform.position;   
    }

	private void Update()
	{
        m_targetPosition = m_initialPosition;
        m_targetPosition.y = m_targetPosition.y+Mathf.Cos(Time.realtimeSinceStartup * Mathf.PI * Frequency) * Amplitude ;

        transform.position = m_targetPosition;
    }


}
