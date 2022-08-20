using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A cell on terrain floor. 
/// </summary>
public class TerrainCell : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer = null;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        // m_spriteRenderer.color = Color.white;
    }

    private void OnMouseExit()
    {
        // m_spriteRenderer.color = Color.red;
    }
}
