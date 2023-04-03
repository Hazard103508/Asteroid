using RossoGame.Environmet;
using System;
using UnityEngine;
using UnityShared.Structs;

namespace RossoGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Meteor", menuName = "ScriptableObjects/Meteor", order = 2)]
    public class MeteorScriptableObject : ScriptableObject
    {
        public InnerMeteor innerMeteors;
        public int score;
        public RangeNumber<float> speedRange;

        [Serializable]
        public class InnerMeteor
        {
            public Meteor prefab;
            public int count;
        }
    }
}