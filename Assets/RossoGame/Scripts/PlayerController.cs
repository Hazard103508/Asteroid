using System.Security.Cryptography;
using UnityEngine;
using static UnityShared.Behaviours.Sprite.SpriteKeepInBounds;

namespace RossoGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public MissilesHandler missileHandler;
        public float rotationSpeed;
        public float moveSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            Rotate();
            Shoot();
        }

        public void ResetInertiaY(BoundHit boundHit) => _rigidbody.velocity *= Vector2.right;
        public void ResetInertiaX(BoundHit boundHit) => _rigidbody.velocity *= Vector2.up;
        private void Move()
        {
            var velocity = Vector2.up * Mathf.Max(0, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
            _rigidbody.AddRelativeForce(velocity, ForceMode2D.Force);
        }
        private void Rotate()
        {
            var _rotation = Vector3.back * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Rotate(_rotation);
        }
        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                missileHandler.Shoot();
        }
    }
}
