using UnityEngine;
using UnityShared.Structs;

namespace RossoGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Meteor", menuName = "ScriptableObjects/Meteor", order = 1)]
    public class MeteorScriptableObject : ScriptableObject
    {
        public GameObject smallMeteorPref;
        public RangeNumber<float> speedRange;
        public int score;
    }
}