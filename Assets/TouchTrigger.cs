using System;
using UnityEngine;
using UnityEngine.Events;

public class TouchTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTouch;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameHelper.PLAYER_TAG))
            _onTouch?.Invoke();
    }
}
