using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool IsonGround;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float JumpForce;
    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;
    private Animator playerAnimator;

    private Rigidbody rigidbodyPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
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
        if (GameManager.IsDialogStarted == false)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetShieldInput();
        }
    }

    private void GetShieldInput()
    {
        if (Input.GetMouseButton(1))
        {
            playerAnimator.SetBool("IsShield",true);
        }
        else
        {
            playerAnimator.SetBool("IsShield", false);

        }
    }

    private void GetMovementInput()
    {
        if (!playerAnimator.GetBool("IsAttacked") && !playerAnimator.GetBool("IsShield"))
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
            rigidbodyPlayer.velocity = new Vector3(horizontalInput * speed * Time.deltaTime, rigidbodyPlayer.velocity.y, verticalInput * speed * Time.deltaTime);


            SetBlendTreeValues(horizontalInput, verticalInput);


            if (horizontalInput != 0 || verticalInput != 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
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



    private void SetBlendTreeValues(float horizontal = 0, float vertical = 0)
    {
        float blend = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        if (blend >= 1)
        {
            playerAnimator.SetFloat("Blend", 1f);
        }
        else
        {
            playerAnimator.SetFloat("Blend", blend);
        }
    }


    private void GetAttackInput()
    {
        float fire1Input = Input.GetAxis("Fire1");

        if (fire1Input != 0)
        {
            playerAnimator.SetBool("IsAttacked", true);
        }
        else
        {
            playerAnimator.SetBool("IsAttacked", false);
        }

    }
}
