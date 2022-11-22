using UnityEngine;
using UnityEngine.UI;

namespace PVZ
{
/// <summary>
/// Attach this script to an UI element, mouse click will create a plant to be planted
/// </summary>
public class PlantResource : MonoBehaviour
{
    // The plant's prefab to instantiate, will be initialized in GameManager::Awake()
    private Plant m_plantPrefab = null;

    // The text for sunlight cost
    private TMPro.TextMeshProUGUI m_cost_Text = null;

    // The icon for plant's prefab
    private Image m_plantIcon_Image = null;

    // Cached game manager instance
    private GameManager m_gameManager = null;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// Implementation for EventTrigger.OnPointerDown. Should select this handled plant and ready to be plant
    /// </summary>
    public void OnPointerDownImpl()
    {
        Debug.Assert(m_plantPrefab != null);

        if (m_gameManager.SunlightCount >= m_plantPrefab.Cost &&    // Has enough sunlight
            m_gameManager.SelectedPlant != m_plantPrefab)           // Would like to select another plant
        {
            m_gameManager.SelectedPlant = m_plantPrefab;
            m_gameManager.SelectedPlant_Image.sprite = m_plantIcon_Image.sprite;
            m_gameManager.SelectedPlant_Image.color = Color.white;            
        }
    }

    /// <summary>
    /// Expected to be called during Awake() by game manager
    /// </summary>
    /// <param name="plant">The plant this resource bar is going to handle</param>
    public void SetPlant(Plant plant) 
    {
        m_plantPrefab = plant;

        m_plantIcon_Image = transform.GetChild(0).GetComponent<Image>();
        m_plantIcon_Image.sprite = m_plantPrefab.IconSprite;

        m_cost_Text = transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        m_cost_Text.text = m_plantPrefab.Cost.ToString();
    }
}
}