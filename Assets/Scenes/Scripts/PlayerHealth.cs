using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Heart _heartPrefab;
    [SerializeField] private GameObject _healthBar;

    public event UnityAction Died;
    public List<Heart> _hearts;
    private int _currentHealth;
    private int _lengthBetweenHearts;

    private void Awake()
    {
        _lengthBetweenHearts = 95;
        _currentHealth = 0;
        FillHearts();
    }

    private void FillHearts()
    {
        _hearts = new List<Heart>();

        for (int i = 0; i < _maxHealth; i++)
        {
            AddHeart(i);
        }
    }

    private void AddHeart(int count)
    {
        _currentHealth++;

        if (_currentHealth <= _maxHealth)
        {
            Heart heart = Instantiate(_heartPrefab, _healthBar.transform);
            _hearts.Add(heart);
            heart.GetComponent<RectTransform>().anchoredPosition = new Vector2(count * _lengthBetweenHearts, 0);            
        }
        else
        {
            _currentHealth = _maxHealth;
        }
    }

    private void GetDamage()
    {
        _currentHealth--;

        if (_currentHealth > 0)
        {
            Heart nextHeart = _hearts[_currentHealth];
            _hearts.Remove(nextHeart);
            nextHeart.DestroyHeart();
        }
        else
        {
            Died?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            GetDamage();
        }
        else if (collision.TryGetComponent<Cherri>(out Cherri cherri))
        {
            AddHeart(_currentHealth);
        }
    }
}
