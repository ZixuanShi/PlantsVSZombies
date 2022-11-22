using UnityEngine;

namespace PVZ
{
public class LinearMover : MonoBehaviour
{
    [Tooltip("Which way to move"), SerializeField]
    private Vector3 m_direction = Vector3.left;

    [Tooltip("How fast this object to move")]
    [SerializeField]
    [Range(0.0f, float.MaxValue)]
    private float m_moveSpeed = 5.0f;

    public bool CanMove { get; set; } = true;

    private void Update()
    {
        if (CanMove)
        {
            transform.position += m_direction * m_moveSpeed * Time.deltaTime;
        }
    }
}
}
