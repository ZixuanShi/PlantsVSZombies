using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
