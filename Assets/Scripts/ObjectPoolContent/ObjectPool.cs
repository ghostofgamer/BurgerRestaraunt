using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ObjectPoolContent
{
    public class ObjectPool <T>where T: MonoBehaviour
    {
        private Transform _container;
        private T _prefab;
        private List<T> _poolGeneric;
    
        public bool AutoExpand { get; private set; }
        
        public ObjectPool(T prefab, int count, Transform container,DiContainer diContainer)
        {
            _prefab = prefab;
            _container = container;
            GetInitialization(count, prefab,diContainer);
        }

        public bool TryGetObject(out T spawned, T prefabs)
        {
            var filter = _poolGeneric.Where(p => p.gameObject.activeSelf == false);
            var index = Random.Range(0, filter.Count());

            if (filter.Count() == 0 && AutoExpand)
            {
                spawned = CreateObject(prefabs);
                return spawned != null;
            }

            spawned = filter.ElementAt(index);
            spawned.gameObject.SetActive(true);
            return spawned != null;
        }

        public void SetAutoExpand(bool flag)
        {
            AutoExpand = flag;
        }

        public void Reset()
        {
            foreach (var item in _poolGeneric)
                item.gameObject.SetActive(false);
        }

        private void GetInitialization(int count, T prefabs,DiContainer diContainer)
        {
            _poolGeneric = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var spawned = diContainer.InstantiatePrefabForComponent<T>(prefabs, _container.transform);
                spawned.gameObject.SetActive(false);
                _poolGeneric.Add(spawned);
            }
        }
    
        private T CreateObject(T prefabs)
        {
            var spawned = Object.Instantiate(prefabs, _container.transform);
            spawned.gameObject.SetActive(true);
            _poolGeneric.Add(spawned);
            return spawned;
        }
    }
}
