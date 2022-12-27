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
    }
}
