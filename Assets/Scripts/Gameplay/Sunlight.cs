using UnityEngine;

namespace PVZ
{
/// <summary>
/// Sunlight to be collected on the game map with mouse clicks
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Sunlight : MonoBehaviour
{
    [SerializeField]
    private int m_amount = 50;

    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().AddSunlightCount(m_amount);
        Destroy(gameObject);
    }

    public void SetAmount(int amount) { m_amount = amount; }
}
}