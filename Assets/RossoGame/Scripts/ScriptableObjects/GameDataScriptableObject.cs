using UnityEngine;

namespace RossoGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 100)]
    public class GameDataScriptableObject : ScriptableObject
    {
        public int score;
        public int lifes;
    }
}