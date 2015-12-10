using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Smoothing = 5f;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPosition = Target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, Smoothing * Time.deltaTime);
    }

}
