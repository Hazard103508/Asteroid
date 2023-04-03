using UnityEngine;
using UnityEngine.Events;

namespace RossoGame.Environmet
{
    public class Missile : MonoBehaviour
    {
        public float speed;
        public UnityEvent onCollided;

        public void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        public void SetCollided()
        {
            onCollided.Invoke();
            gameObject.SetActive(false);
        }
    }
}