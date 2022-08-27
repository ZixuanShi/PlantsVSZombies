using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Resource of Plant that can be planted in the game. Attach this script to an UI element
/// </summary>
public class PlantResource : MonoBehaviour
{
    private Plant m_plantPrefab = null;

    private TMPro.TextMeshProUGUI m_cost_Text = null;
    private Image m_plantIcon_Image = null;
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

        if (m_gameManager.SunlightCount >= m_plantPrefab.Cost)
        {
            m_gameManager.SelectedPlant = m_plantPrefab;
            m_gameManager.SelectedPlant_Image.sprite = m_plantIcon_Image.sprite;
            m_gameManager.SelectedPlant_Image.color = Color.white;
            m_gameManager.AddSunlightCount(-m_plantPrefab.Cost);
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
