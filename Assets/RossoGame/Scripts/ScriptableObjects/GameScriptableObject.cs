using RossoGame.Environmet;
using UnityEngine;

namespace RossoGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game", menuName = "ScriptableObjects/Game", order = 100)]
    public class GameScriptableObject : ScriptableObject
    {
        public Meteor meteorPrefab;
        public float meteorDelay;
    }
}