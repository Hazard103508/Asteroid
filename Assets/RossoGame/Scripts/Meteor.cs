using UnityEngine;

namespace RossoGame
{
    public class Meteor : MonoBehaviour
    {
        public GameObject smallMeteorPref;

        private float speed;
        private float rotation;
        private Vector3 direction;

        private void Awake()
        {
            speed = Random.Range(1f, 3f);
            rotation = Random.Range(3, 90f);
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        private void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }

        public void InvertX() => direction *= new Vector2(-1, 1);
        public void InvertY() => direction *= new Vector2(1, -1);

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "missile")
            {
                collision.gameObject.SetActive(false);
                BreakMeteor();
            }
        }
        private void BreakMeteor()
        {
            if (smallMeteorPref != null)
                for (int i = 0; i < 2; i++)
                {
                    var obj = Instantiate(smallMeteorPref);
                    obj.transform.position = this.transform.position;
                }

            Destroy(gameObject);
        }

    }
}