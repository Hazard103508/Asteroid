using RossoGame.Environmet;
using RossoGame.ScriptableObjects;
using System.Linq;
using UnityEngine;
using UnityShared.Behaviours.Sprite;
using UnityShared.Extensions.CSharp;

namespace RossoGame
{
    public class GameHandler : MonoBehaviour
    {
        public GameDataScriptableObject gameData;
        public Transform meteorPool;
        public Meteor meteorPref;
        public float meteorDelay;

        private void Awake()
        {
            InvokeRepeating("InstantiateRandomMeteor", 1, meteorDelay);
        }

        private void InstantiateRandomMeteor() => InstantiateMeteor(meteorPref);
        private void InstantiateMeteor(Meteor prefab, Vector3? position = null)
        {
            var meteor = Instantiate(prefab, meteorPool);

            if (position.HasValue)
                meteor.transform.position = position.Value;
            else
            {
                var bounds = meteor.GetComponent<SpriteOutBoundsTrigger>();
                float x = new float[] { bounds.BorderLeft, bounds.BorderRight }.Choose(1).First();
                float y = Random.Range(bounds.BorderTop, bounds.BorderBottom);
                meteor.transform.position = new Vector3(x, y, 0);
            }

            meteor.onDestroy.AddListener(OnDestroyMeteor);
        }

        private void OnDestroyMeteor(Meteor meteor)
        {
            if (meteor.data.innerMeteors.count > 0)
                for (int i = 0; i < meteor.data.innerMeteors.count; i++)
                    InstantiateMeteor(meteor.data.innerMeteors.prefab, meteor.transform.position);

            gameData.score += meteor.data.score;
            Destroy(meteor.gameObject);
        }
    }
}