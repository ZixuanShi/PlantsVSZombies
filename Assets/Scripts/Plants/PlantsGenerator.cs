using System.Collections.Generic;
using UnityEngine;

namespace PVZ
{
public class PlantsGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Plant> m_chosenPlants = new List<Plant>();

    [SerializeField]
    private GameObject m_plantResourcesBar_Panel = null;

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
}