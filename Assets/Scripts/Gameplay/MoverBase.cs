using Unity.VisualScripting;
using UnityEngine;

namespace PVZ
{
    public abstract class MoverBase : MonoBehaviour
    {
        [field: SerializeField]
        public bool CanMove { get; set; } = true;

        [Tooltip("How fast this object to move")]
        [field: SerializeField]
        public float MoveSpeed { get; set; } = 5.0f;

        private void Update()
        {
            if (CanMove)
            {
                Move();
            }
        }

        protected abstract void Move();
    }
}