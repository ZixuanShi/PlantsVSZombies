using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMover : MonoBehaviour
{
    [Tooltip("Which way to move")]
    [SerializeField]
    private Vector3 m_direction = Vector3.left;

    [Tooltip("How fast this object to move")]
    [SerializeField]
    private float m_moveSpeed = 5.0f;

    public bool CanMove { get; private set; } = true;

    private void Update()
    {
        if (CanMove)
        {
            transform.position += m_direction * m_moveSpeed * Time.deltaTime;
        }
    }
}
