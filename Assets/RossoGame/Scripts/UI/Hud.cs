using RossoGame.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace RossoGame.UI
{
    public class Hud : MonoBehaviour
    {
        public ScoreScriptableObject scoreData;
        public Text labelScore;

        private void LateUpdate()
        {
            labelScore.text = scoreData.score.ToString();
        }
    }
}