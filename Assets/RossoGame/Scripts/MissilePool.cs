using System.Collections.Generic;
using UnityEngine;

namespace RossoGame
{
    public class MissilePool : MonoBehaviour
    {
        public GameObject missilePref;
        public int ammo;
        public float missilSeed;

        private List<Rigidbody2D> missiles;
        private int missileIndex = 0;

        private void Awake()
        {
            InstantiateMissiles();
        }

        public void Shoot()
        {
            var missile = missiles[missileIndex];

            if (missile.gameObject.activeSelf)
                return; // no hay misil disponible

            missile.gameObject.SetActive(true);
            missile.transform.localPosition = Vector3.zero;
            missile.transform.localRotation = Quaternion.identity;
            missile.AddRelativeForce(Vector2.up * missilSeed * Time.deltaTime, ForceMode2D.Impulse);

            missileIndex = missileIndex == missiles.Count - 1 ? 0 : missileIndex + 1;
        }

        private void InstantiateMissiles()
        {
            missiles = new List<Rigidbody2D>();
            for (int i = 0; i < ammo; i++)
            {
                var obj = Instantiate(missilePref);
                missiles.Add(obj.GetComponent<Rigidbody2D>());
            }
        }
    }
}