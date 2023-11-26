using System;
using UnityEngine;

namespace Scenes.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpy;
        private Rigidbody2D _body;
        private bool _isJumping;
        public Animator anim;
        public AudioSource JumpSound;
        public int SoundToken;

        private void Awake()

        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _body.velocity.y);
         
            

            

            if (Input.GetKey(KeyCode.Space) && !_isJumping)
            { 
                _body.velocity = new Vector2(_body.velocity.x,jumpy);
                _isJumping = true;
            }

            if (_isJumping)
            {
                anim.SetBool("Jump", true);
                if (SoundToken == 1)
                {
                    JumpSound.Play();
                }
                SoundToken =- 1;
            }
        }

        private void FixedUpdate()
        {
            float move = Input.GetAxis("Horizontal");

            // Check if the player is moving horizontally
            if (Mathf.Abs(move) > 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isJumping = false;
                anim.SetBool("Jump", false);
                SoundToken =+ 1;
            }
            
        }
    }
}
