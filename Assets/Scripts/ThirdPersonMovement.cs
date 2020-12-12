using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Character character;
    [SerializeField]
    private float smoothRotationTime = 0.05f;
    private float currentSmoothVelocity;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private Transform cam;

    void Start()
    {
        character = GetComponent<Character>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.01)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.rotation.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref currentSmoothVelocity, smoothRotationTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Move player toward camera direction
            character.Move(Quaternion.Euler(0, targetAngle, 0) * Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
