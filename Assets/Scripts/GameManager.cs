using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Plant> m_chosenPlants = new List<Plant>();

    [SerializeField]
    private HorizontalLayoutGroup m_plantResourcesBar_Panel = null;

    [field: SerializeField]
    public Image SelectedPlant_Image { get; set; } = null;

    public Plant SelectedPlant { get; set; } = null;

    private void Awake()
    {
        Debug.Assert(m_chosenPlants.Count <= m_plantResourcesBar_Panel.transform.childCount);

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
    }
}
