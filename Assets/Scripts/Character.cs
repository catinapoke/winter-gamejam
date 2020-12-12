using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const int MAX_HEALTH = 100;
    const float MAX_SIZE = 1.0f;
    private int _health = 100;
    private bool _isInColdZone = false;
    private float _size = 1.0f;

    public int Health { get { return _health; } }
    public bool IsInColdZone { get { return _isInColdZone; } set { _isInColdZone = value; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Vector3 movement)
    {
        transform.Translate(movement, Space.World);
    }

    public void IncreaseHealth(int amount)
    {
        _health = Mathf.Clamp(_health + amount, 0, MAX_HEALTH);
    }

    public void DecreaseHealth(int amount)
    {
        _health = Mathf.Clamp(_health - amount, 0, MAX_HEALTH);
    }

    public void IncreaseSize(float amount)
    {
        _size = Mathf.Clamp(_size + amount, 0, MAX_SIZE);
        transform.localScale = new Vector3(_size, _size, _size);
    }

    public void DecreaseSize(float amount)
    {
        _size = Mathf.Clamp(_size - amount, 0, MAX_SIZE);
        transform.localScale = new Vector3(_size, _size, _size);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Cold zone"))
        {
            _isInColdZone = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Cold zone"))
        {
            _isInColdZone = false;
        }
    }

}
