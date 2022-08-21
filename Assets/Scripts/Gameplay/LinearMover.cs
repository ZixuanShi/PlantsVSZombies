using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMover : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_direction = Vector3.left;

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
