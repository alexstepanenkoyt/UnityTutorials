using UnityEngine;

namespace Assets.Scripts.Youtube.Pool
{
    public class CoinPoolable : Poolable 
    {
        private void Update()
        {
            if (_isActive)
            {
                transform.rotation *= Quaternion.AngleAxis(Time.deltaTime * 50f, Vector3.up);
            }
        }

        public override void OnSpawn(Transform parentTransform)
        {
            base.OnSpawn(parentTransform);

            gameObject.SetActive(true);
            SetToDefault(parentTransform);
        }

        public override void OnDeSpawn(Transform parentTransform)
        {
            base.OnDeSpawn(parentTransform);

            gameObject.SetActive(false);
            SetToDefault(parentTransform);
        }

        private void SetToDefault(Transform parentTransform)
        {
            transform.SetParent(parentTransform);
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }
    }
}
