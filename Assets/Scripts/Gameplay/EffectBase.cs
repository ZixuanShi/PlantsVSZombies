using System.Collections;
using UnityEngine;

namespace PVZ 
{
    public abstract class EffectBase : MonoBehaviour
    {
        public abstract void ApplyToObject(ObjectBase objectBase);
        public abstract void ApplyToProjectile(Projectile projectile);
        protected abstract IEnumerator Restore(ObjectBase objectBase);
    }
}