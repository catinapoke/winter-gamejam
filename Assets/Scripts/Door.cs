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
        transform.localRotation = Quaternion.Euler(_isClosed ? _closedRotation : _openRotation);
    }

    public void Use(bool open)
    {
        if (_isRunning || _isClosed != open) return;
        _isClosed = !open;
        
        if(_openRoutine != null)
            StopCoroutine(_openRoutine);
        
        _openRoutine = OpenSmooth(_openTime, open);
        StartCoroutine(_openRoutine);
    }

    private IEnumerator OpenSmooth(float time, bool close)
    {
        _isRunning = true;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(close ? _openRotation : _closedRotation );
        for (float i = 0; i < time; i+= Time.deltaTime)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, i/time);
            yield return null;
        }

        _isRunning = false;
    }
}
