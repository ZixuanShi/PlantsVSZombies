using UnityEngine;

namespace PVZ
{
    public class LinearMover : MonoBehaviour
    {
        [Tooltip("Which way to move"), SerializeField]
        [field: SerializeField]
        public Vector3 Direction { get; set; } = Vector3.left;

        [Tooltip("How fast this object to move")]
        [field: SerializeField]
        public float MoveSpeed { get; set; } = 5.0f;

        [field: SerializeField]
        public bool CanMove { get; set; } = true;

        private void Update()
        {
            if (CanMove)
            {
                transform.position += Direction * MoveSpeed * Time.deltaTime;
            }
        }
    }
}
