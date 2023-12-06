using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _world;


    public GameObject Spawn(string path, Vector3 position, Quaternion rotation)
    {
        return Instantiate(Resources.Load<GameObject>(path), position, rotation, _world);
    }
}
