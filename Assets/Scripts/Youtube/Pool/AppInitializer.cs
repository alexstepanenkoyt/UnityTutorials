using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Youtube.Pool
{
    public class AppInitializer : MonoBehaviour
    {
        [SerializeField] private Poolable _prefab;
        [SerializeField] private Button _pushButton;
        [SerializeField] private Button _pullButton;
        [SerializeField] private Transform _activeParentTransform;

        private Pool _pool;
        private Queue<Poolable> _activeObjects;

        private void Awake()
        {
            GameObject poolObject = new GameObject();
            poolObject.name = $"Pool[{_prefab.GetType()}]";
            poolObject.transform.position = new Vector3(-100f, 0f, 0f);

            _pool = poolObject.AddComponent<Pool>();
            _pool.Init(_prefab, 10);
            
            _activeObjects = new Queue<Poolable>();

            _pushButton.onClick.AddListener(PushObjectToPull);
            _pullButton.onClick.AddListener(GetObjectFromPull);
        }

        private void GetObjectFromPull()
        {
            var obj = _pool.Pull();
            obj.OnSpawn(_activeParentTransform);

            _activeObjects.Enqueue(obj);
        }

        private void PushObjectToPull()
        {
            if (_activeObjects.Count > 0)
            {
                _pool.Push(_activeObjects.Dequeue());
            }
        }
    }
}
