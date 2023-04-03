using RossoGame.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RossoGame.Environmet
{
    public class MissilesHandler : MonoBehaviour
    {
        public PlayerScriptableObject playerData;
        public Transform missileCannon;
        public Transform missilePool;

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

            for (int i = 0; i < playerData.missile.ammo; i++)
            {
                var missile = Instantiate(playerData.missile.missile, missilePool);
                missile.onCollided.AddListener(() => missilesInactive.Enqueue(missile));
                missilesInactive.Enqueue(missile);
            }
        }
    }
}