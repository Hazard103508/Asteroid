using RossoGame.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace RossoGame.Environmet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        public PlayerScriptableObject playerData;
        public GameObject flameLeft;
        public GameObject flameRight;

        private Rigidbody2D _rigidbody;
        private MissilesHandler missileHandler;

        public UnityEvent onDestroyed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            missileHandler = GetComponent<MissilesHandler>();
        }

        private void Update()
        {
            Move();
            Rotate();
            Shoot();
        }

        private void Move()
        {
            var velocity = Vector2.up * Mathf.Max(0, Input.GetAxis("Vertical")) * playerData.player.moveSpeed * Time.deltaTime;
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
            var _rotation = Vector3.back * Input.GetAxis("Horizontal") * playerData.player.rotationSpeed * Time.deltaTime;
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
                var effect = Instantiate(playerData.player.explotionEffect);
                effect.transform.position = this.transform.position;

                onDestroyed.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}
