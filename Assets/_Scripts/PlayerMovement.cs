using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotateSpeed = 100f;

    private Rigidbody rb;

    private float horizontal;
    private float vertical;
    private float mouseX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Read input here
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
    }

    void FixedUpdate()
    {
        // Rotate always (even when not moving)
        Quaternion rotation = Quaternion.Euler(0, mouseX * rotateSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);

        // Movement
        Vector3 moveDir = transform.forward * vertical + transform.right * horizontal;
        Vector3 targetPos = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);
    }
}
