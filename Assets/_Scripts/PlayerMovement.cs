using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private Animator animator;

    private float horizontal;
    private float vertical;
    private float mouseX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Read input here
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 rotateY = new Vector3(0, mouseX * rotateSpeed * Time.deltaTime, 0);

        if (movement != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateY));
        }

        rb.MovePosition(rb.position + (transform.forward * vertical + transform.right * horizontal) * moveSpeed * Time.deltaTime);

        if (animator != null)
        {
            animator.SetFloat("BlendV", vertical);
            animator.SetFloat("BlendH", horizontal);
        }
    }
}
