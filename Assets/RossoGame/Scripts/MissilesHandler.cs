using System.Collections.Generic;
using UnityEngine;

namespace RossoGame
{
    public class MissilesHandler : MonoBehaviour
    {
        public GameObject missilePref;
        public Transform missileCannon;
        public Transform folder;
        public int ammo;
        public float missilSeed;

        private List<Missile> missiles;
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
            missile.transform.position = missileCannon.transform.position;
            missile.transform.localRotation = this.transform.localRotation;

            missileIndex = missileIndex == missiles.Count - 1 ? 0 : missileIndex + 1;
        }

        private void InstantiateMissiles()
        {
            missiles = new List<Missile>();
            for (int i = 0; i < ammo; i++)
            {
                var obj = Instantiate(missilePref, folder);
                missiles.Add(obj.GetComponent<Missile>());
            }
        }
    }
}