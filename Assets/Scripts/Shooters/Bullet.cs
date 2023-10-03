using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Vector2 _direction = Vector2.right;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
        else if (collision.TryGetComponent(out Bird bird))
            bird.TakeDamage(_damage);

        gameObject.SetActive(false);    
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SetStartPosition(Vector3 startPosition)
    {
        transform.position = startPosition;
    }
}
