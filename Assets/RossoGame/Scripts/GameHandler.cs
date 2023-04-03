using RossoGame.Environmet;
using RossoGame.ScriptableObjects;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityShared.Behaviours.Handlers;
using UnityShared.Behaviours.Sprite;
using UnityShared.Extensions.CSharp;

namespace RossoGame
{
    public class GameHandler : MonoBehaviour
    {
        public ScoreScriptableObject scoreData;
        public GameScriptableObject gameData;
        public Transform meteorPool;
        public PanelHandler gameOverPanel;

        private bool isPlaying;

        public UnityEvent onMeteorDestroed;

        private void Awake()
        {
            isPlaying = true;
            scoreData.score = 0;
            Invoke("InstantiateRandomMeteor", 0);
        }

        public void OnPlayerDestroy() => Invoke("ShowGameOver", 1);
        public void OnReplay() => SceneHandler.Instance.Restart(UnityShared.Enums.LoadSceneBehaviour.Async);
        public void OnExit() 
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }

        private void InstantiateRandomMeteor()
        {
            InstantiateMeteor(gameData.meteorPrefab);

            if (isPlaying)
                Invoke("InstantiateRandomMeteor", gameData.meteorDelay);
        }
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

            scoreData.score += meteor.data.score;
            Destroy(meteor.gameObject);

            onMeteorDestroed.Invoke();
        }
        private void ShowGameOver()
        {
            isPlaying = false;
            gameOverPanel.Show();
        }
    }
}