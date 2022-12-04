using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PVZ
{
    /// <summary>
    /// Generates zombies in waves, attach to game manager
    /// </summary>
    public class ZombieGenerator : MonoBehaviour
    {
        [SerializeField]
        private List<Plant> m_chosenZombies = new List<Plant>();

        private GameManager m_gameManager = null;

        private List<Vector3> m_zombieSpawningPositions = new List<Vector3>();

        private void Awake()
        {
            m_gameManager = FindObjectOfType<GameManager>();

            ZombieSpawningPoint spawningPoint = FindObjectOfType<ZombieSpawningPoint>();
            foreach (Transform child in spawningPoint.transform)
            {
                m_zombieSpawningPositions.Add(child.transform.position);
            }
        }

        private IEnumerator SpawnZombies()
        {
            while (true)
            {


                yield return null;
            }
        }
    }
}