using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;
    }
}
