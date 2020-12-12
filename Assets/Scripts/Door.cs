using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _isClosed;
    [SerializeField] private float _openTime = 1.0f;
    [SerializeField] private Vector3 _openRotation;
    [SerializeField] private Vector3 _closedRotation;
    [SerializeField] private IEnumerator _openRoutine;
    private bool _isRunning = false;
    
    private void Start()
    {
        transform.rotation = Quaternion.Euler(_isClosed ? _closedRotation : _openRotation);
    }

    public void Use(bool open)
    {
        if (_isRunning) return;
        
        StopCoroutine(_openRoutine);
        _openRoutine = OpenSmooth(_openTime, open);
        StartCoroutine(_openRoutine);
    }

    private IEnumerator OpenSmooth(float time, bool open)
    {
        _isRunning = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(open ? _openRotation : _closedRotation);
        for (float i = 0; i < time; i+= Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, i/time);
            yield return null;
        }

        _isRunning = false;
    }
}
