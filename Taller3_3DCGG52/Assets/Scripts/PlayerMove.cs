using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedMove = 5.0f;
    public float speedRotation = 200.0f;
    public float speedRun = 10.0f;
    public float jumpforce = 5.0f;
    private Animator anim;
    public float x, y;
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        isRunning = Input.GetKey(KeyCode.LeftShift) && y > 0;

        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
        float currentSpeed = isRunning ? speedRun : speedMove; 
        transform.Translate(0, 0, y * Time.deltaTime * currentSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
            isGrounded = false;
        }

        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
        anim.SetBool("IsRunning", isRunning);
        anim.SetBool("IsGrounded", isGrounded);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
