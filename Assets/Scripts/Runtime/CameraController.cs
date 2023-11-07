using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float distance;
    public void LateUpdate()
    {
        if (null == target)
            return;

        transform.position = target.transform.position - Vector3.forward * distance;
    }
}
