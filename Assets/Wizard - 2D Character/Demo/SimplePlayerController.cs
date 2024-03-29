﻿using UnityEngine;

namespace ClearSky
{
      public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        public bool isStepGenerate = false;

        [SerializeField] MagicBase speedUpMagic;
        [SerializeField] MagicBase hiJunpMagic;
        [SerializeField] MagicBase attackMagic;
        [SerializeField] MagicBase stepGenerateMagic;
        [SerializeField] PlayerStatus playerStatus;
        [SerializeField] GameObject craftUI;

        public MagicBase HiJumpMagic { get { return hiJunpMagic; } }

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    speedUpMagic.OnCall();
                }
                if (Input.GetKeyDown(KeyCode.G)) {
                    hiJunpMagic.OnCall();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("fuck");
                    attackMagic.OnCall();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    stepGenerateMagic.OnCall();
                    isStepGenerate = true;
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    InventoryUI.Instance.gameObject.SetActive(!InventoryUI.Instance.gameObject.activeSelf);
                }
                Hurt();
                Die();
                Attack();
                Jump();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
                transform.position += moveVelocity * movePower * Time.deltaTime * speedUpMagic.effectPower;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower * hiJunpMagic.effectPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack");
                    //playerStatus.currentHp -= 30;
                    //Debug.Log($"現在HP{playerStatus.currentHp}");

            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}