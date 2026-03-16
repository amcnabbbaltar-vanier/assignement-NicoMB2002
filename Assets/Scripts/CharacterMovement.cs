using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runMultiplier = 1.2f;
    public float minJumpForce = 4f;
    public float maxJumpForce = 12f;
    public float maxHoldTime = 3f;
    public bool hasDoubleJumpPower = false;
    public float doubleJumpForce = 10f;
    private Rigidbody rb;
    private bool isGrounded;
    private bool canDoubleJump;
    private bool isChargingJump;
    private float jumpHoldTime;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        HandleJumpInput();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        float currentSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed *= runMultiplier;

        rb.velocity = new Vector3(move * currentSpeed, rb.velocity.y, 0);

        if (animator)
            animator.SetFloat("Speed", Mathf.Abs(move));
    }

    void HandleJumpInput()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isChargingJump = true;
            jumpHoldTime = 0f;
        }

        if (isChargingJump && Input.GetKey(KeyCode.Space))
        {
            jumpHoldTime += Time.deltaTime;

            if (jumpHoldTime >= maxHoldTime)
                PerformGroundJump();
        }

        if (isChargingJump && Input.GetKeyUp(KeyCode.Space))
            PerformGroundJump();

        if (!isGrounded && hasDoubleJumpPower && canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            PerformDoubleJump();
    }

    void PerformGroundJump()
    {
        isChargingJump = false;

        float t = Mathf.Clamp01(jumpHoldTime / maxHoldTime);
        float force = Mathf.Lerp(minJumpForce, maxJumpForce, t);

        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);

        canDoubleJump = true;

        if (animator)
            animator.SetTrigger("Jump");
    }

    void PerformDoubleJump()
    {
        canDoubleJump = false;

        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);

        if (animator)
            animator.SetTrigger("DoubleJump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

}
