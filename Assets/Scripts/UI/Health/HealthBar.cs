using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Heart _heartPrefab;

    private List<Heart> _hearts = new List<Heart>();

    private void Start()
    {
        for (int i = 0; i < _bird.MaxHealth; i++)
        {
            CreateHeart();
        }
    }

    private void OnEnable()
    {
        _bird.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _bird.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int heartCount)
    {
        var hearts = _hearts.Where(heart => heart.gameObject.activeSelf == true).ToList();        

        if (heartCount == _bird.MaxHealth)
        {
            RestartHeart();
        }       
        else if (heartCount < hearts.Count)
        {
            int destroyHeartCount = hearts.Count - heartCount;

            for (int i = 0; i < destroyHeartCount; i++)
            {
                hearts[hearts.Count - (i + 1)].ToEmpty();
            }
        }
    }

    private void CreateHeart()
    {
        Heart heart = Instantiate(_heartPrefab, transform);
        heart.ToFill();
        _hearts.Add(heart);
    }

    private void RestartHeart()
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            _hearts[i].gameObject.SetActive(true);
            _hearts[i].ToFill();
        }
    }
}
