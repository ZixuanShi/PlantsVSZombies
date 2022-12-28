using UnityEngine;

namespace PVZ
{
    /// <summary>
    /// Projectile to be shot by shooters
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        // Will be set by the shooter's damage
        private int m_damage = 0;

        // The effect to apply when hit an object
        private EffectBase m_effect = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.TakeDamage(m_damage);

                if (m_effect != null)
                {
                    m_effect.ApplyToObject(zombie);
                }

                Destroy(gameObject);
            }
        }

        public void SetDamage(int damage) 
        { 
            m_damage = damage;
        }

        public void SetEffect(EffectBase effect) 
        { 
            m_effect = effect;
            if (effect != null)
            {
                effect.ApplyToProjectile(this);
            }
        }
    }
}