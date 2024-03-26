using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_Camera
{
    public class CameraPanning : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float smoothing = 5f;
        [SerializeField] private Vector2 range = new (100, 100);

        private Vector3 targetPosition;
        private Vector3 input;

        private void Awake()
        {
            targetPosition = transform.position;
        }

        private void HandleInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 right = transform.right * x;
            Vector3 forward = transform.forward * z;

            input = (forward + right).normalized;
        }

        private void Move()
        {
            Vector3 nextTargetPosition = targetPosition + input * speed;
            if (IsInBounds(nextTargetPosition)) targetPosition = nextTargetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothing);
        }

        private bool IsInBounds(Vector3 position)
        {
            return position.x > -range.x &&
                position.x < range.x &&
                position.z > -range.y &&
                position.z < range.y;
        }

        private void Update()
        {
            HandleInput();
            Move();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 5f);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(range.x * 2f, 5f, range.y * 2f));
        }

    }
}
