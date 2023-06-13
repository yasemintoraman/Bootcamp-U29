using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool IsonGround;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float jumpInput;

    private Rigidbody rigidbodyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsonGround = true;
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        GetMovementInput();
        GetJumpInput();
    }
    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        rigidbodyPlayer.velocity = new Vector3(horizontalInput * speed * Time.deltaTime, rigidbodyPlayer.velocity.y, verticalInput * speed * Time.deltaTime);


        if (horizontalInput != 0 || verticalInput != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private void GetJumpInput()
    {
        jumpInput = Input.GetAxis("Jump");
        if (jumpInput != 0 && IsonGround)
        {
            rigidbodyPlayer.velocity = Vector3.up * JumpForce;
            IsonGround = false;
        }
    }
}
