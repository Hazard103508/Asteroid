using UnityEngine;

namespace RossoGame.Environmet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public GameObject explotionEffectPref;
        public GameObject flameLeft;
        public GameObject flameRight;
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

        private void Move()
        {
            var velocity = Vector2.up * Mathf.Max(0, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
            _rigidbody.AddRelativeForce(velocity, ForceMode2D.Force);

            bool showFlame = velocity.y > 0;
            if (flameLeft.activeSelf != showFlame)
            {
                flameLeft.gameObject.SetActive(showFlame);
                flameRight.gameObject.SetActive(showFlame);
            }
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "meteor")
            {
                var effect = Instantiate(explotionEffectPref);
                effect.transform.position = this.transform.position;

                Destroy(this.gameObject);
            }
        }
    }
}
