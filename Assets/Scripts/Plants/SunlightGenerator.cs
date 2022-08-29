using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates sunlight with the given cooldown
/// </summary>
public class SunlightGenerator : MonoBehaviour
{
    [SerializeField]
    private int m_amount = 50;

    [SerializeField]
    private float m_cooldown = 5.0f;

    [SerializeField]
    private Sunlight m_sunlightPrefab = null;

    private void Awake()
    {
        StartCoroutine(GenerateSunlight());
    }

    private IEnumerator GenerateSunlight()
    {
        // Skip the first round
        yield return new WaitForSeconds(m_cooldown);

        while (true)
        {
            Sunlight sunlight = Instantiate(m_sunlightPrefab, transform.position, transform.rotation);
            sunlight.SetAmount(m_amount);

            yield return new WaitForSeconds(m_cooldown);
        }
    }
}
