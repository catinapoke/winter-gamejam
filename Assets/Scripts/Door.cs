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

    public void Use(bool close)
    {
        if (_isRunning || _isClosed == close) return;
        _isClosed = close;
        StopCoroutine(_openRoutine);
        _openRoutine = OpenSmooth(_openTime, close);
        StartCoroutine(_openRoutine);
    }

    private IEnumerator OpenSmooth(float time, bool close)
    {
        _isRunning = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(close ? _closedRotation : _openRotation );
        for (float i = 0; i < time; i+= Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, i/time);
            yield return null;
        }

        _isRunning = false;
    }
}
