using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Vector3 targetPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                targetPosition = hit.point;
                targetPosition.y = transform.position.y;
            }
        }

        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 targetDirection = targetPosition - transform.position;
        targetDirection.y = 0f;
        if (targetDirection.magnitude > 0.1f)
        {
            Vector3 moveDirection = targetDirection.normalized * moveSpeed * Time.deltaTime;
            controller.Move(moveDirection);
        }
    }
}
