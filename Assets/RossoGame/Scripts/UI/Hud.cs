using RossoGame.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace RossoGame.UI
{
    public class Hud : MonoBehaviour
    {
        public GameDataScriptableObject gameData;
        public Text labelScore;

        private void LateUpdate()
        {
            labelScore.text = gameData.score.ToString();
        }
    }
}