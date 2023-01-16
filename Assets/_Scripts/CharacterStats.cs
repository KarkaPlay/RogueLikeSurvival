using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    [SerializeField] private Slider healthSlider;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        SetSliderValue();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        SetSliderValue();
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void SetSliderValue()
    {
        healthSlider.value = (float)_currentHealth / _maxHealth;
    }

    protected virtual void Die()
    {
    }
}