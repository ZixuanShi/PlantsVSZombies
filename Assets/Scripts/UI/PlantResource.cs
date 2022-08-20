using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Resource of Plant that can be planted in the game. Attach this script to an UI element
/// </summary>
public class PlantResource : MonoBehaviour
{
    [SerializeField]
    private Plant m_plant = null;

    private TMPro.TextMeshProUGUI m_cost_Text = null;
    private Image m_plantIcon_Image = null;
    
    private void Awake()
    {
        m_plantIcon_Image = transform.GetChild(0).GetComponent<Image>();
        m_cost_Text = transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void OnPointerDownImpl()
    {
        Debug.Assert(m_plant != null);

        Image image = GameObject.Find("SelectedPlant_Image").GetComponent<Image>();
        image.sprite = m_plantIcon_Image.sprite;
        
    }

    public void SetPlant(Plant plant) { m_plant = plant; }
}
