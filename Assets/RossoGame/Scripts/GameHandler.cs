using RossoGame.Environmet;
using RossoGame.ScriptableObjects;
using UnityEngine;

namespace RossoGame
{
    public class GameHandler : MonoBehaviour
    {
        public GameDataScriptableObject gameData;

        [Header("Prefabs")]
        public Meteor meteorPref;

        private void Awake()
        {
            InstantiateMeteors(meteorPref, new Vector3(2, 2, 0));
        }

        private void InstantiateMeteors(Meteor prefab, Vector3 position)
        {
            var meteor = Instantiate(prefab);
            meteor.transform.position = position;
            meteor.onDestroy.AddListener(OnDestroyMeteor);
        }

        private void OnDestroyMeteor(Meteor meteor)
        {
            if (meteor.data.innerMeteors.count > 0)
                for (int i = 0; i < meteor.data.innerMeteors.count; i++)
                    InstantiateMeteors(meteor.data.innerMeteors.prefab, meteor.transform.position);

            gameData.score += meteor.data.score;
            Destroy(meteor.gameObject);
        }
    }
}