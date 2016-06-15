using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Soldier : MonoBehaviour
    {
        private bool jumping;
        public static bool Paused;
        public static Soldier Character;
        public float MovementSensitivity;
        private float VerticalSpeed;
        private float HorizontalSpeed;
        private bool Crouching;
        private bool Alive;
        public int Health = 100;
        private bool Sprinting;
        private bool Shooting;
        private float Gravity = 0.5f;
        private Animator playersAnimator;
        private Animator fpsAnimator;
        private CharacterController controller;
        private GameObject PlayerView;
        private GameObject FPSView;
        private Rigidbody characterRigitBody;

        void Start()
        {
            characterRigitBody = GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;
            if (PlayerPrefs.HasKey("Health"))
                Health = PlayerPrefs.GetInt("Health");
            Character = this;
            this.PlayerView = transform.GetChild(0).gameObject;
            this.FPSView = transform.GetChild(1).GetChild(0).gameObject;
            this.controller = GetComponent<CharacterController>();
            this.playersAnimator = this.PlayerView.GetComponent<Animator>();
            fpsAnimator = FPSView.GetComponent<Animator>();
            this.Alive = true;
        }

        void Update()
        {
            if (Paused)
            {
                playersAnimator.speed = 0;
                fpsAnimator.speed = 0;
                return;
            }
            else
            {
                playersAnimator.speed = 1;
                fpsAnimator.speed = 0;
            }
            Shooting = Input.GetMouseButton(0);
            this.VerticalSpeed = Input.GetAxis("Vertical");
            this.HorizontalSpeed = Input.GetAxis("Horizontal");
            this.Sprinting = Input.GetButton("Sprint");
            this.Crouching = Input.GetButton("Crouch");
            if (this.Sprinting && !this.Shooting && this.VerticalSpeed > 0)
            {
                this.VerticalSpeed *= 2;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
                StartCoroutine(JumpTimer());
            }
            Animate();
            if (Health <= 0)
            {
                PlayerPrefs.SetString("Result", "Game Over");
                SceneManager.LoadScene("EndGame");
            }
        }

        IEnumerator JumpTimer()
        {
            yield return new WaitForSeconds(0.5f);
            jumping = false;
        }
        void FixedUpdate()
        {
            if (Paused) return;
            Move();
        }

        void Animate()
        {
            if (Shooting)
                fpsAnimator.speed = 0;
            else fpsAnimator.speed = 1;
            this.playersAnimator.SetBool("Crouching", this.Crouching);
            this.playersAnimator.SetBool("Grounded", this.controller.isGrounded);
            this.playersAnimator.SetFloat("InputX", this.HorizontalSpeed);
            this.playersAnimator.SetFloat("InputY", this.VerticalSpeed);
        }

        void Move()
        {
            float verticalMovement = VerticalSpeed / MovementSensitivity;
            float horizontalMovement = HorizontalSpeed / MovementSensitivity;
            Vector3 Desiredmove = Vector3.zero;

            if (verticalMovement != 0 || horizontalMovement != 0)
                Desiredmove = transform.forward * verticalMovement + transform.right * horizontalMovement;

            if (!jumping)
                Desiredmove.y = -Gravity;
            else Desiredmove.y = Gravity;
            this.controller.Move(Desiredmove / 10);
        }
        public void DealDamage(int damage)
        {
            Health -= damage;
            PlayerPrefs.SetInt("Health", Health);
        }
    }
}
