using UnityEngine;

/// <summary>
/// Set this UI element always follow mouse's position
/// </summary>
public class MouseFollower : MonoBehaviour
{
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
