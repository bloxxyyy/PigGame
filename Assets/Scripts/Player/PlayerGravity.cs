using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerGravity : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    private float gravity = 9.81f;

    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            Vector3 gravityVector = Vector3.down * gravity * Time.fixedDeltaTime;
            controller.Move(gravityVector);
        }
    }
}
