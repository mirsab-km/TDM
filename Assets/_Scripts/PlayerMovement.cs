using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private Animator animator;

    private float horizontal;
    private float vertical;
    private float mouseX;
    private bool canJump;

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

        canJump = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Rotation
        Vector3 rotateY = new Vector3(0, mouseX * rotateSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateY));

        //Movement
        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        // Animation
        if (animator != null)
        {
            animator.SetFloat("BlendV", vertical);
            animator.SetFloat("BlendH", horizontal);
        }
    }

}
