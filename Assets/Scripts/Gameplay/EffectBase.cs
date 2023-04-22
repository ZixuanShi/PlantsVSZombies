using System.Collections;
using UnityEngine;

namespace PVZ 
{
    /// <summary>
    /// Base class for effects. Attach to a plant
    /// </summary>
    public abstract class EffectBase : MonoBehaviour
    {
        public abstract void ApplyToObject(ObjectBase objectBase);
        public abstract void ApplyToProjectile(Projectile projectile);
        protected abstract IEnumerator Restore(ObjectBase objectBase);
    }
}