using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float _smoothRotationTime = 0.05f;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _moveSpeed = 2.0f;

    private float _currentSmoothVelocity;
    private Character _character;

    void Start()
    {
        _character = GetComponent<Character>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude > float.Epsilon)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.rotation.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle,
                ref _currentSmoothVelocity, _smoothRotationTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Move player toward camera direction
            _character.Move(Quaternion.Euler(0, targetAngle, 0) * Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }
}