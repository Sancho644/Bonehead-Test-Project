using UnityEngine;
using Utils;

namespace Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _destroyObject;
        [SerializeField] private float _destroyDelay;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnInstance();
        }

        private GameObject SpawnInstance()
        {
            var instance = SpawnUtils.Spawn(_prefab, _target.position);

            if (_destroyObject)
                Destroy(instance, _destroyDelay);

            return instance;
        }
    }
}