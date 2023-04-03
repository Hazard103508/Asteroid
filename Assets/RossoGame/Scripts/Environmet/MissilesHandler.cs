using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RossoGame.Environmet
{
    public class MissilesHandler : MonoBehaviour
    {
        public Missile missilePref;
        public Transform missileCannon;
        public Transform folder;
        public int ammo;
        public float missilSeed;

        private Queue<Missile> missilesInactive;
        private Queue<Missile> missilesActive;

        private void Awake()
        {
            InstantiateMissiles();
        }

        public void Shoot()
        {
            if (!missilesInactive.Any())
                return;

            var missile = missilesInactive.Dequeue();
            missilesActive.Enqueue(missile);

            missile.gameObject.SetActive(true);
            missile.transform.position = missileCannon.transform.position;
            missile.transform.localRotation = this.transform.localRotation;
        }

        private void InstantiateMissiles()
        {
            missilesInactive = new Queue<Missile>();
            missilesActive = new Queue<Missile>();

            for (int i = 0; i < ammo; i++)
            {
                var missile = Instantiate(missilePref, folder);
                missile.onCollided.AddListener(() => missilesInactive.Enqueue(missile));
                missilesInactive.Enqueue(missile);
            }
        }
    }
}