using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates zombies
/// </summary>
public class ZombieGenerator : MonoBehaviour
{
    [SerializeField]
    private float m_cooldown = 5.0f;

    [SerializeField]
    private List<Zombie> m_chosenZombies = new List<Zombie>();

    [SerializeField]
    private List<int> m_chosenZombiesCount = new List<int>();

    private List<Vector3> m_zombieSpawningPositions = new List<Vector3>();
    private IEnumerator m_spawnZombieCoroutine = null;

    private void Awake()
    {
        ZombieSpawningPoint spawningPoint = FindObjectOfType<ZombieSpawningPoint>();
        foreach (Transform child in spawningPoint.transform)
        {
            m_zombieSpawningPositions.Add(child.transform.position);
        }

        m_spawnZombieCoroutine = SpawnZombie();
        StartCoroutine(m_spawnZombieCoroutine);
    }

    private IEnumerator SpawnZombie()
    {
        while (true)
        {
            //m_chosenZombies.Keys;

            yield return new WaitForSeconds(m_cooldown);
        }
    }
}
