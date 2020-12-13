using System;
using UnityEngine;
using UnityEngine.Events;

public class TouchTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTouch;
    [SerializeField] private string _objectTag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_objectTag))
            _onTouch?.Invoke();
    }
}
