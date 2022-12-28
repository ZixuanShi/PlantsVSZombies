using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PVZ
{
    /// <summary>
    /// Bare minimal class for plants and zombies
    /// </summary>
    public class ObjectBase : MonoBehaviour
    {
        [field: SerializeField]
        public Sprite IconSprite { get; private set; } = null;

        [field: SerializeField]
        public int Heath { get; protected set; } = 10;

        [field: SerializeField]
        public int Damage { get; private set; } = 5;

        // Key for the effect, value for the coroutine caused by that effect
        private Dictionary<EffectBase, IEnumerator> m_appliedEffects = new Dictionary<EffectBase, IEnumerator>();

        /// <summary>
        /// Apply damage to this object, destroy this object if health is below 0
        /// </summary>
        /// <param name="damage"></param>
        public virtual void TakeDamage(int damage)
        {
            Heath -= damage;
            if (Heath <= 0)
            {
                Destroy(gameObject);
            }
        }

        /// <returns>true if this object has already applied the given effect, false if not</returns>
        /// <param name="effect">The effect to check if applied</param>
        public bool HasEffect(EffectBase effect) 
        { 
            return m_appliedEffects.ContainsKey(effect); 
        }

        /// <summary>
        /// Removes the given effect from applied effects to this object
        /// </summary>
        /// <param name="effect">The effect to remove</param>
        public void RemoveEffect(EffectBase effect)
        {
            m_appliedEffects.Remove(effect);
        }

        /// <summary>
        /// Apply an effect to this object
        /// </summary>
        /// <param name="effect">The effect type to apply</param>
        /// <param name="effectCoroutine">The effect's behavior to perform</param>
        public void ApplyEffect(EffectBase effect, IEnumerator effectCoroutine) 
        {
            if (HasEffect(effect))
            {
                StopCoroutine(m_appliedEffects[effect]);
                RemoveEffect(effect);
            }

            m_appliedEffects.Add(effect, effectCoroutine);
            StartCoroutine(effectCoroutine);
        }
    }
}
