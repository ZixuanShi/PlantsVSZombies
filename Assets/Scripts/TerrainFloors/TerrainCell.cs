using UnityEngine;

namespace PVZ
{
/// <summary>
/// A cell on terrain floor. 
/// </summary>
public class TerrainCell : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer = null;
    private GameManager m_gameManager = null;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (m_gameManager.SelectedPlant != null)
        {
            Instantiate(m_gameManager.SelectedPlant, transform.position, Quaternion.identity);

            m_gameManager.AddSunlightCount(-m_gameManager.SelectedPlant.Cost);
            m_gameManager.SelectedPlant = null;
            m_gameManager.SelectedPlant_Image.sprite = null;
            m_gameManager.SelectedPlant_Image.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnMouseEnter()
    {
        m_spriteRenderer.color = new Color(1, 1, 1, 0.5f);
    }

    private void OnMouseExit()
    {
        m_spriteRenderer.color = new Color(0, 0, 0, 0);
    }
}
}
