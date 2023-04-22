using System.Collections;
using UnityEngine;

namespace PVZ
{
    public class Zombie : ObjectBase
    {
        [SerializeField]
        private AudioClip m_attackAudioClip = null;

        [SerializeField]
        private float m_attackCooldown = 0.7f;

        private Helmet m_helmet = null;

        private AudioSource m_attackSource = null;
        private LinearMover m_linearMover = null;
        private Animator m_animator = null;
        private bool m_isAttacking = false;
        private IEnumerator m_attackCoroutine = null;

        private void Awake()
        {
            m_helmet = GetComponent<Helmet>();
            m_attackSource = GetComponent<AudioSource>();
            m_linearMover = GetComponent<LinearMover>();
            m_animator = GetComponent<Animator>();
            Debug.Assert(m_attackAudioClip != null);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Plant plant = collision.gameObject.GetComponent<Plant>();
            
            // If collided with a plant, we want to attack this plant
            if (plant != null)
            {
                m_linearMover.CanMove = false;
                m_isAttacking = true;
                m_animator.SetBool("IsAttacking", m_isAttacking);
                m_attackCoroutine = Attack(plant);
                StartCoroutine(m_attackCoroutine);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            // If a plant is gone, don't attack any more and continue moving
            if (collision.gameObject.GetComponent<Plant>() != null)
            {
                m_linearMover.CanMove = true;
                m_isAttacking = false;
                m_animator.SetBool("IsAttacking", m_isAttacking);
                StopCoroutine(m_attackCoroutine);
            }
        }

        /// <summary>
        /// Overriden TakeDamage function for zombies
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            // If a helmet presents, use it to take damage first, then take the left overs if there's any
            if (m_helmet != null && !m_helmet.IsBroken())
            {
                damage = m_helmet.TakeDamage(damage);                
            }

            if (damage > 0)
            {
                Heath -= damage;
            }

            if (Heath <= 0)
            {
                StartCoroutine(OnDead());
            }
        }

        /// <summary>
        /// Attacks a targetted plant
        /// </summary>
        /// <param name="plant">The plant to attack</param>
        private IEnumerator Attack(Plant plant)
        {
            while (m_isAttacking)
            {
                plant.TakeDamage(Damage);
                m_attackSource.PlayOneShot(m_attackAudioClip, PlayerSettingsManager.s_SoundEffectsVolumeScale);
                yield return new WaitForSeconds(m_attackCooldown);
            }
        }

        /// <summary>
        /// Sequence of Todo list when a zombie is dead
        /// </summary>
        /// <returns></returns>
        private IEnumerator OnDead()
        {
            // Stop attacking
            m_isAttacking = false;

            // Set animation to play death
            m_animator.SetBool("IsDead", true);

            // Figure out the time to wait for death animation
            float waitTime = 0.0f;
            RuntimeAnimatorController runtimeAnimatorController = m_animator.runtimeAnimatorController;
            for (int i = 0; i < runtimeAnimatorController.animationClips.Length; ++i)
            {
                if (runtimeAnimatorController.animationClips[i].name == "Zombie_Animation_Dead")
                {
                    waitTime = runtimeAnimatorController.animationClips[i].length;
                    break;
                }
            }

            // Wait until the animation ends
            yield return new WaitForSeconds(waitTime);

            // This Zombie officially dies now
            Destroy(gameObject);
        }
    }
}
