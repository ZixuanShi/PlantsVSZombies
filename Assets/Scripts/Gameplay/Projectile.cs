using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 2.0f;

    private int m_damage = 0;

    private void Update()
    {
        transform.position += m_speed * Vector3.right * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Zombie zombie = collision.gameObject.GetComponent<Zombie>();
        if (zombie != null)
        {
            zombie.TakeDamage(m_damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage) { m_damage = damage; }
}
