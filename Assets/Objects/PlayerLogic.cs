using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Logic : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;
        public float gravity;
        private float yVelocity;

        private bool facingRight = false;

        [HideInInspector] public bool deathState = false;

        private bool isGrounded = false;
        public Transform groundCheck;

        private new Rigidbody2D rigidbody;
        private Animator animator;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            
        }

        void Update()
        {
            CheckGround();
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                //rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                yVelocity -= jumpForce;
            }

            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }

            if (!isGrounded)
            {
                yVelocity += gravity;
            }
            else
            {
                yVelocity = 0;
            }

            Vector3 newPos = transform.localPosition;
            newPos.y += yVelocity;
            transform.localPosition = newPos;
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }
    }
}
