using UnityEngine;

public class HandlerValueService : MonoBehaviour
{
    [SerializeField] private string _pathBullet = "Bullet";
    [SerializeField] private string _pathEnemy = "Enemy";
    [SerializeField] private string _pathBarrel = "Barrel";

    public string PathBullet1 => _pathBullet;
    public string PathEnemy1 => _pathEnemy;
    public string PathBarrel1 => _pathBarrel;
}
