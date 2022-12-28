using System.Collections;
using UnityEngine;

namespace PVZ
{
    /// <summary>
    /// Slows the hit object's movement speed
    /// </summary>
    public class SlowEffect : EffectBase
    {
        [Range(0, 1)]
        private const float m_slowMultiplier = 0.25f;

        [Range(0.0f, float.MaxValue)]
        private const float m_slowDurationSeconds = 1.0f;

        private float m_originalSpeed = 0.0f;

        /// <summary>
        /// Slow the given object
        /// </summary>
        /// <param name="objectBase"></param>
        public override void ApplyToObject(ObjectBase objectBase)
        {
            // If the object is not slowed already, apply the slowing effect to it
            if (!objectBase.HasEffect(this))
            {
                // Slow movement
                MoverBase moverBase = objectBase.GetComponent<MoverBase>();
                m_originalSpeed = moverBase.MoveSpeed;
                moverBase.MoveSpeed *= m_slowMultiplier;

                // Slow animation
                Animator animator = objectBase.GetComponent<Animator>();
                animator.SetFloat("PlaySpeed", m_slowMultiplier);

                // Make the object looks frozen
                foreach (SpriteRenderer childSpriteRenderer in objectBase.transform.GetComponentsInChildren<SpriteRenderer>())
                {
                    childSpriteRenderer.color = Color.cyan;
                }
            }

            objectBase.ApplyEffect(this, Restore(objectBase));
        }

        /// <summary>
        /// Color the projectile to cyan
        /// </summary>
        /// <param name="projectile">The projectile that's carrying this slow effect</param>
        public override void ApplyToProjectile(Projectile projectile)
        {
            projectile.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        /// <summary>
        /// Restore from slowed status
        /// </summary>
        /// <param name="objectBase">The object been slowed</param>
        protected override IEnumerator Restore(ObjectBase objectBase)
        {
            yield return new WaitForSeconds(m_slowDurationSeconds);

            MoverBase moverBase = objectBase.GetComponent<MoverBase>();
            moverBase.MoveSpeed = m_originalSpeed;

            Animator animator = objectBase.GetComponent<Animator>();
            animator.SetFloat("PlaySpeed", 1);

            foreach (SpriteRenderer childSpriteRenderer in objectBase.transform.GetComponentsInChildren<SpriteRenderer>())
            {
                childSpriteRenderer.color = Color.white;
            }

            objectBase.RemoveEffect(this);
        }
    }
}