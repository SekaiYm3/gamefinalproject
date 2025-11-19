using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -5f;

    float velocityY = 0f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        velocityY += gravity * Time.deltaTime;

        Vector3 input = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        ).normalized;

        Vector3 temp = Vector3.zero;

        if (input.z == 1)
            temp += transform.forward;
        else if (input.z == -1)
            temp -= transform.forward;

        if (input.x == 1)
            temp += transform.right;
        else if (input.x == -1)
            temp -= transform.right;

        Vector3 velocity = temp * speed;
        velocity.y = velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
            velocityY = 0;
    }
}
