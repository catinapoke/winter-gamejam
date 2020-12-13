using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _position;

    public void Spawn()
    {
        Instantiate(_prefab, _position, Quaternion.identity);
    }
}