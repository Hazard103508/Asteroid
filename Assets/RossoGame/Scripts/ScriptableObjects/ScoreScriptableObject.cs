using UnityEngine;

namespace RossoGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 3)]
    public class ScoreScriptableObject : ScriptableObject
    {
        public int score;
    }
}