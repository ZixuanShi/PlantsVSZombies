using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates zombies in waves
/// </summary>
public class ZombieGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Zombie> m_chosenZombiePrefabs = new List<Zombie>();

    private List<Vector3> m_zombieSpawningPositions = new List<Vector3>();

    private void Awake()
    {
        ZombieSpawningPoint spawningPoint = FindObjectOfType<ZombieSpawningPoint>();
        foreach (Transform child in spawningPoint.transform)
        {
            m_zombieSpawningPositions.Add(child.transform.position);
        }

        int randomSpawningPositionIndex = UnityEngine.Random.Range(0, m_zombieSpawningPositions.Count);

        Instantiate(m_chosenZombiePrefabs[0], m_zombieSpawningPositions[randomSpawningPositionIndex], Quaternion.identity);
    }
}
