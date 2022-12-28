using UnityEngine;

namespace PVZ
{
    public class LinearMover : MoverBase
    {
        [Tooltip("Which way to move"), SerializeField]
        [field: SerializeField]
        public Vector3 Direction { get; set; } = Vector3.left;

        protected override void Move()
        {
            transform.position += Direction * MoveSpeed * Time.deltaTime;
        }
    }
}
