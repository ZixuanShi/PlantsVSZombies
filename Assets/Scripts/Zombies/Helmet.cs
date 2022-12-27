using UnityEngine;

namespace PVZ
{
    /// <summary>
    /// Body armor for a zombie, can take damage until this Helmet pops off
    /// </summary>
    [RequireComponent(typeof(Zombie))]
    public class Helmet : MonoBehaviour
    {
        [Tooltip("Durability this helmet has")]
        [SerializeField]
        [Range(0, int.MaxValue)]
        private int m_durability = 10;

        [Tooltip("Helmet's Sprite when full 100% to 66%")]
        [SerializeField]
        private Sprite m_spriteFullHP = null;

        [Tooltip("Helmet's Sprite when full 66% to 33%")]
        [SerializeField]
        private Sprite m_spriteHalfHP = null;

        [Tooltip("Helmet's Sprite when full 33% to 0%")]
        [SerializeField]
        private Sprite m_spriteLowHP = null;

        private SpriteRenderer m_spriteRenderer = null;

        // The current durability. Init with m_durability Will be substracted when taking damage. And removed from zombie when below 0
        private int m_currentDurability = int.MinValue;

        private void Awake()
        {
            m_currentDurability = m_durability;

            Transform[] children = transform.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in children)
            {
                if (child.name == "Helmet")
                {
                    m_spriteRenderer = child.gameObject.GetComponent<SpriteRenderer>();
                }
            }
        }

        /// <summary>
        /// Take damage. Update helmet sprite if needed
        /// </summary>
        /// <param name="damage">the damage to substract durability</param>
        /// <returns>How many damage left that's not fully taken by this helmet</returns>
        public int TakeDamage(int damage)
        { 
            int leftOverDamage = -(m_currentDurability - damage);
            m_currentDurability -= damage;

            if (m_currentDurability < m_durability && m_currentDurability > m_durability * 0.66f)
            {
                m_spriteRenderer.sprite = m_spriteFullHP;
            }
            else if (m_currentDurability < m_durability * 0.66f && m_currentDurability > m_durability * 0.33f)
            {
                m_spriteRenderer.sprite = m_spriteHalfHP;
            }
            else if (m_currentDurability < m_durability * 0.33f && m_currentDurability > 0.0f)
            {
                m_spriteRenderer.sprite = m_spriteLowHP;
            }
            else if (m_currentDurability <= 0.0f)
            {
                m_spriteRenderer.sprite = null;
            }

            return leftOverDamage;
        }

        /// <returns>true if this helmet is broken, false if not</returns>
        public bool IsBroken() { return m_currentDurability <= 0; }
    }
}