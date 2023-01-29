using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Youtube.Pool
{
    public class Pool : MonoBehaviour
    {
        private Poolable _prefab;
        private Queue<Poolable> _objects;

        public void Init(Poolable prefab, int amount)
        {
            _prefab = prefab;
            _objects = new Queue<Poolable>(amount);

            for (int i = 0; i < amount; i++)
            {
                _objects.Enqueue(InstantiatePrefab());
            }
        }

        private Poolable InstantiatePrefab()
        {
            var obj = Instantiate(_prefab, Vector3.zero, Quaternion.identity, transform);
            obj.OnDeSpawn(transform);

            return obj;
        }

        public Poolable Pull()
        {
            var obj = _objects.Count == 0 ? InstantiatePrefab() : _objects.Dequeue();

            return obj;
        }

        public void Push(Poolable obj)
        {
            _objects.Enqueue(obj);

            obj.OnDeSpawn(transform);
        }
    }
}
