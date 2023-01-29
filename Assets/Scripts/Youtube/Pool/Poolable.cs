using UnityEngine;

namespace Assets.Scripts.Youtube.Pool
{
    public abstract class Poolable : MonoBehaviour
    {
        protected bool _isActive;

        public virtual void OnSpawn(Transform parentTransform)
        {
            _isActive = true;
        }

        public virtual void OnDeSpawn(Transform parentTransform)
        {
            _isActive = false;
        }
    }
}
