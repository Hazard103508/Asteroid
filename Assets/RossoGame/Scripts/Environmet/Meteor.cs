using RossoGame.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace RossoGame.Environmet
{
    public class Meteor : MonoBehaviour
    {
        public MeteorScriptableObject data;

        private float speed;
        private float rotation;
        private Vector3 direction;

        public UnityEvent<Meteor> onDestroy;

        private void Awake()
        {
            speed = Random.Range(data.speedRange.min, data.speedRange.max);
            rotation = Random.Range(3, 90f);
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        private void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "missile")
            {
                collision.gameObject.GetComponent<Missile>().SetCollided();
                onDestroy.Invoke(this);
            }
        }
    }
}