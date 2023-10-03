using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdTracker))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<Enemy> Died;

    private Bird _target;
    private BirdTracker _birdTracker;

    private void Awake()
    {
        _birdTracker = GetComponent<BirdTracker>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void Init(Bird target)
    {
        _target = target;
        _birdTracker.SetTarget(target);
    }

    private void Die()
    {
        Died?.Invoke(this);
        gameObject.SetActive(false);
    }
}
