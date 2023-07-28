using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _prefab;

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        SpawnInstance();
    }

    private GameObject SpawnInstance()
    {
        var instance = SpawnUtils.Spawn(_prefab, _target.position);

        return instance;
    }
}