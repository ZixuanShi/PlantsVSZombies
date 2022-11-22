using System.Collections;
using UnityEngine;

namespace PVZ
{
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

    private readonly Vector2 kMin = new Vector2(-6.10f,  2.52f);
    private readonly Vector2 kMax = new Vector2( 3.53f, -3.28f);

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
            Vector3 spawnPosition = Vector3.zero;

            if (GetComponent<Plant>() != null)
            {
                spawnPosition = transform.position;
            }
            else
            {
                spawnPosition.x = Random.Range(kMin.x, kMax.x);
                spawnPosition.y = Random.Range(kMin.y, kMax.y);
            }

            Sunlight sunlight = Instantiate(m_sunlightPrefab, spawnPosition, transform.rotation);
            sunlight.SetAmount(m_amount);

            yield return new WaitForSeconds(m_cooldown);
        }
    }
}
}
