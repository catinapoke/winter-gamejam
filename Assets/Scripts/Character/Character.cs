using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _maxSize = 1.0f;
    [SerializeField] private float _healthIncreaseSpeed = 10.0f;
    [SerializeField] private float _healthDecreaseSpeed = 1.0f;


    public float CurrentHealth => _currentHealth;
    public event Action<Character> OnCharacterDied;

    private float _currentHealth = 100;
    private bool _isCold = false;
    private ParticleSystem _water_particles;

    private List<ColdZone> _zones = new List<ColdZone>();
    
    private void Awake()
    {
        _water_particles = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        float gain = _healthIncreaseSpeed * (_isCold ? _healthIncreaseSpeed : -_healthDecreaseSpeed);
        IncreaseHealth(gain * Time.fixedDeltaTime);
        SetSize(Mathf.Lerp(0, _maxSize, _currentHealth / _maxHealth));
        
        // Particle system handling
        if (!_isCold)
        {
            _water_particles.Play();
        }
        else
        {
            _water_particles.Stop();
        }
    }

    public void RegisterZone(ColdZone zone)
    {
        _zones.Add(zone);
        _isCold = true;
    }

    public void UnregisterZone(ColdZone zone)
    {
        _zones.Remove(zone);
        _isCold = _zones.Count > 0;
    }

    public void Move(Vector3 movement)
    {
        transform.Translate(movement, Space.World);
    }

    private void IncreaseHealth(float amount)
    {
        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);
        if(_currentHealth<0f)
            OnCharacterDied?.Invoke(this);
    }

    private void SetSize(float amount)
    {
        transform.localScale = new Vector3(amount, amount, amount);
    }
}
