using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Plant> m_chosenPlants = new List<Plant>();

    [SerializeField]
    private GameObject m_plantResourcesBar_Panel = null;

    [field: SerializeField]
    public Image SelectedPlant_Image { get; set; } = null;

    [Tooltip("Current sunlight count the player owns. Changed by collecting sunlight or planting plants")]
    [SerializeField]
    private int m_sunlight = 0;

    [SerializeField]
    private TMPro.TMP_Text m_sunlightText = null;

    public Plant SelectedPlant { get; set; } = null;

    private void Awake()
    {
        Debug.Assert(m_chosenPlants.Count <= m_plantResourcesBar_Panel.transform.childCount);

        m_sunlightText.text = m_sunlight.ToString();

        // For each child of plantResourcesBar_Panel,
        // If we have chosen a plant that's meant to be at this resource bar index, set the UI as we wanted to.
        // If the current index has no chosen plant, set it inactive
        for (int i = 0; i < m_plantResourcesBar_Panel.transform.childCount; ++i)
        {
            if (i < m_chosenPlants.Count)
            {
                m_plantResourcesBar_Panel.transform.GetChild(i).GetComponent<PlantResource>().SetPlant(m_chosenPlants[i]);
            }
            else
            {
                m_plantResourcesBar_Panel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        m_sunlightText.text = m_sunlight.ToString();
    }

    /// <summary>
    /// Add an offset to sunlight count
    /// </summary>
    /// <param name="offset">Offset for sunlight, could be negative for reducing sunlight</param>
    public void AddSunlightCount(int offset)
    {
        m_sunlight += offset;
        m_sunlightText.text = m_sunlight.ToString();
    }
}
