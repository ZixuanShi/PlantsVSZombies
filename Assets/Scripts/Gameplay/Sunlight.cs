using System.Collections;
using UnityEngine;

namespace PVZ
{
    /// <summary>
    /// Sunlight to be collected on the game map with mouse clicks
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(LinearMover))]
    public class Sunlight : MonoBehaviour
    {
        [SerializeField]
        private int m_amount = 50;

        // The sunlight's image on UI
        private SunlightImage m_sunlightImage = null;

        private void Awake()
        {
            m_sunlightImage = FindObjectOfType<SunlightImage>();
        }

        private void OnMouseDown()
        {
            StartCoroutine(MoveToSunlightUIImage());
        }

        /// <summary>
        /// Moves towards to the sunlight's UI image
        /// </summary>
        private IEnumerator MoveToSunlightUIImage()
        {
            // Initialize linear mover's direction and enable it
            LinearMover linearMover = GetComponent<LinearMover>();
            Vector3 sunlightImageWorldPosition = Camera.main.ScreenToWorldPoint(m_sunlightImage.transform.position);
            sunlightImageWorldPosition.z = 0.0f;
            linearMover.Direction = (sunlightImageWorldPosition - transform.position).normalized;
            linearMover.CanMove = true;

            // While not close enough to the sunlight image, move towards to it and speed up
            while (!HasReachedSunlightImage(sunlightImageWorldPosition))
            {
                linearMover.MoveSpeed += Time.deltaTime;
                yield return null;
            }

            // When close enough to the sunlight image, increase the player's sunlight's count and destroy this sunlight object
            FindObjectOfType<GameManager>().AddSunlightCount(m_amount);
            Destroy(gameObject);
        }

        /// <param name="sunlightImageWorldPosition">World space position of the sunlight UI image</param>
        /// <returns>true if close enough to the sunlight Image world position, flase if not</returns>
        private bool HasReachedSunlightImage(Vector3 sunlightImageWorldPosition)
        {
            const float kCloseDistance = 0.5f;
            return Vector3.Distance(sunlightImageWorldPosition, transform.position) < kCloseDistance;
        }

        public void SetAmount(int amount) { m_amount = amount; }
    }
}