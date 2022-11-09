using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : ObjectBase
{
    [SerializeField]
    private AudioClip m_attackAudioClip = null;

    [SerializeField]
    private float m_attackCooldown = 0.7f;

    private AudioSource m_attackSource = null;
    private LinearMover m_linearMover = null;
    private Animator m_animator = null;
    private bool m_isAttacking = false;
    private IEnumerator m_attackCoroutine = null;

    private void Awake()
    {
        m_attackSource = GetComponent<AudioSource>();
        m_linearMover = GetComponent<LinearMover>();
        m_animator = GetComponent<Animator>();
        Debug.Assert(m_attackAudioClip != null);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Plant plant = collision.gameObject.GetComponent<Plant>();

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
        if (collision.gameObject.GetComponent<Plant>() != null)
        {
            m_linearMover.CanMove = true;
            m_isAttacking = false;
            m_animator.SetBool("IsAttacking", m_isAttacking);
            StopCoroutine(m_attackCoroutine);
        }
    }

    private IEnumerator Attack(Plant plant)
    {
        while (m_isAttacking)
        {
            plant.TakeDamage(Damage);
            m_attackSource.PlayOneShot(m_attackAudioClip);
            yield return new WaitForSeconds(m_attackCooldown);
        }
    }
}
