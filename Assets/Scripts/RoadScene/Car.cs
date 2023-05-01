using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 forward;
    private Rigidbody m_rigidbody;

    private Transform m_playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody= GetComponent<Rigidbody>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating(nameof(DestorySelf), 10f, 5f);
    }

    void DestorySelf()
    {
        if (Vector3.Distance(transform.position, m_playerTransform.position) >= 2000f)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.MovePosition(transform.position + speed * Time.deltaTime *forward);
    }
}
