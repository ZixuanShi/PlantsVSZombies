using System.Collections;
using UnityEngine;

namespace PVZ
{
/// <summary>
/// Attach to a plant, shoot a projectile if there's a zombie in front of this plant
/// </summary>
[RequireComponent(typeof(Plant))]
public class Shooter : MonoBehaviour
{
    [Tooltip("Cooldown to shoot a bullet")]
    [SerializeField] private float m_cooldown = 5.0f;

    [Tooltip("The projectile's prefab to instantiate when shooting")]
    [SerializeField] private Projectile m_projectilePrefab = null;

    [Tooltip("How far this shooter can shoot")]
    [SerializeField] private float m_range = 10.0f;

    private Plant m_ownerPlant = null;
    private Vector3 m_shootPosition = Vector3.zero;

    private void Awake()
    {
        m_ownerPlant = GetComponent<Plant>();

        Transform shootPoint = m_ownerPlant.transform.Find("ShootPosition");
        Debug.Assert(shootPoint != null);
        m_shootPosition = shootPoint.position;

        StartCoroutine(ShootIfHasTarget());
    }

    /// <summary>
    /// Check if there's any target to shoot in front of this plant
    /// </summary>
    /// <returns>true if there's a target, false if there's none</returns>
    private bool HasTarget()
    {
        // Issue a raycast, see if hit any zombie
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.right, m_range, LayerMask.GetMask("Zombies"));
        if (raycastHit2D.collider != null)
        {
            Zombie zombieComponent = raycastHit2D.collider.gameObject.GetComponent<Zombie>();
            return zombieComponent != null;
        }
        return false;
    }

    private IEnumerator ShootIfHasTarget()
    {
        while (true)
        {
            if (HasTarget())
            {
                Projectile projectile = Instantiate(m_projectilePrefab, m_shootPosition, Quaternion.identity);
                projectile.SetDamage(m_ownerPlant.Damage);
            }

            yield return new WaitForSeconds(m_cooldown);
        }
    }
}
}
