using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraController : MonoBehaviour
{
    private Vector3 mOffset;
    [SerializeField]
    private Transform mPlayerTransform;

    void Start()
    {
        mOffset = transform.position - mPlayerTransform.position;
    }

    public void Update()
    {
        transform.position = mOffset + mPlayerTransform.position;
    }
}
