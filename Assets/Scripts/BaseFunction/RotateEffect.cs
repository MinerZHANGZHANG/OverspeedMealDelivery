using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
    public Vector3 RotateForward= Vector3.up;
    public float RotateSpeed=5f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime * RotateForward);
    }
}
