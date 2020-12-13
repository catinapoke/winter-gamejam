using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TouchTrigger : MonoBehaviour
{
    [FormerlySerializedAs("_onTouch")] [SerializeField] public UnityEvent OnTouch;
    [SerializeField] private string _objectTag;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_objectTag))
            OnTouch?.Invoke();
    }
}
