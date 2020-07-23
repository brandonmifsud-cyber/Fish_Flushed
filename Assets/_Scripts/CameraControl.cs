using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public float offset;
   
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.z = player.position.z + offset;
        transform.position = pos;
    }
}
