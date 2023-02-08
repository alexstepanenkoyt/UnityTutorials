using UnityEngine;

namespace Assets.Scripts.Youtube.Helpers
{
    public class TriggerGizmos : MonoBehaviour
    {
        [SerializeField] private Color _color;

        private Collider _collider;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.matrix = transform.localToWorldMatrix;

            if (_collider == null)
            {
                _collider = GetComponent<Collider>();
            }

            if (_collider is SphereCollider sphereCollider)
            {
                Gizmos.DrawSphere(sphereCollider.center, sphereCollider.radius);
            }
            else if (_collider is BoxCollider boxCollider)
            {
                Gizmos.DrawCube(boxCollider.center, boxCollider.size);
            }
            else if (_collider is MeshCollider meshCollider)
            {
                Gizmos.DrawMesh(meshCollider.sharedMesh);
            }
        }
    }
}
