using UnityEngine;

namespace Scenes.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpy;
        private Rigidbody2D _body;
        private bool _isJumping;

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
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isJumping = false;
            }
            
        }
    }
}
