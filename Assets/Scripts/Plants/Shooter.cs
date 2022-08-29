using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to a plant, shoot a projectile if there's a zombie in front of this plant
/// </summary>
[RequireComponent(typeof(Plant))]
public class Shooter : MonoBehaviour
{
    [SerializeField]
    private float m_cooldown = 5.0f;

    [SerializeField]
    private Projectile m_projectilePrefab = null;

    private Plant m_ownerPlant = null;
    private Vector3 m_shootPosition = Vector3.zero;

    private void Awake()
    {
        m_ownerPlant = GetComponent<Plant>();

        Transform shootPoint = m_ownerPlant.transform.Find("ShootPosition");
        Debug.Assert(shootPoint != null);
        m_shootPosition = shootPoint.position;

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Projectile projectile = Instantiate(m_projectilePrefab, m_shootPosition, Quaternion.identity);
            projectile.SetDamage(m_ownerPlant.Damage);

            yield return new WaitForSeconds(m_cooldown);
        }
    }
}
