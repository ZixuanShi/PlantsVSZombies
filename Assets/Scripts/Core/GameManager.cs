using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PVZ
{
    /// <summary>
    /// Manages a match
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [Tooltip("The plants got chosen to be used in a match")]
        [SerializeField]
        private List<Plant> m_chosenPlants = new List<Plant>();

        [Tooltip("The image that follows the cursor all the time, if we have an active chosen plant, set the image to that plant's icon")]
        [field: SerializeField]
        public Image SelectedPlant_Image { get; set; } = null;

        [Tooltip("Current sunlight count the player owns. Changed by collecting sunlight or planting plants")]
        [field: SerializeField]
        public int SunlightCount { get; private set; } = 0;

        [SerializeField]
        private TMPro.TMP_Text m_sunlightText = null;

        // The percentage of the completion of the current match. 0 means start, 100 means completed
        public int Progression { get; private set; } = 0;

        public Plant SelectedPlant { get; set; } = null;

        private void Awake()
        {
            PlantRecourcesBar_Panel plantResourcesBar_Panel = FindObjectOfType<PlantRecourcesBar_Panel>();
            Debug.Assert(m_chosenPlants.Count <= plantResourcesBar_Panel.transform.childCount);

            m_sunlightText.text = SunlightCount.ToString();

            // For each child of plantResourcesBar_Panel,
            // If we have chosen a plant that's meant to be at this resource bar index, set the UI as we wanted to.
            // If the current index has no chosen plant, set it inactive
            for (int i = 0; i < plantResourcesBar_Panel.transform.childCount; ++i)
            {
                if (i < m_chosenPlants.Count)
                {
                    plantResourcesBar_Panel.transform.GetChild(i).GetComponent<PlantResource>().SetPlant(m_chosenPlants[i]);
                }
                else
                {
                    plantResourcesBar_Panel.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            m_sunlightText.text = SunlightCount.ToString();
        }

        /// <summary>
        /// Add an offset to sunlight count
        /// </summary>
        /// <param name="offset">Offset for sunlight, could be negative for reducing sunlight</param>
        public void AddSunlightCount(int offset)
        {
            SunlightCount += offset;
            m_sunlightText.text = SunlightCount.ToString();
        }
    }
}