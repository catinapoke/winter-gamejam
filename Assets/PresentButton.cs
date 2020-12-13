using System;
using UnityEngine;

public class PresentButton : MonoBehaviour
{
    [SerializeField] private Door _door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameHelper.GIFT_TAG))
        {
            _door.Use(true);
        }
    }
}
