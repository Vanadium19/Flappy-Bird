using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : BulletsPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _shootPoint;

    private float _elapsedTime;
    private Vector2 _direction = Vector2.left;

    private void Start()
    {
        Init(_bulletPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delay)
        {
            Shoot();
            _elapsedTime = 0;
        }
    }

    public void Shoot()
    {
        DisableObjectAbroadScreen();

        if (TryGetBullet(out GameObject bullet))
        {
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetDirection(_direction);
            bullet.GetComponent<Bullet>().SetStartPosition(_shootPoint.position);
        }
    }       
}
