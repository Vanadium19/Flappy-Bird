using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooter : BulletsPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Start()
    {
        Init(_bulletPrefab);
    }

    public void Shoot(Vector2 direction)
    {
        DisableObjectAbroadScreen();

        if (TryGetBullet(out GameObject bullet))
        {
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetDirection(direction);
            bullet.GetComponent<Bullet>().SetStartPosition(_shootPoint.position);
        }
    }
}
