using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour 
{
    [SerializeField] private int _maxHealth;

    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;

    private int _health;
    private int _score;
    private BirdMover _birdMover;

    public int MaxHealth => _maxHealth;
    
    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Died?.Invoke();
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetBird()
    {
        _birdMover.ResetPosition();
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
