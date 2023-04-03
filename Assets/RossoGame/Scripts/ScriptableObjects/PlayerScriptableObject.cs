using RossoGame.Environmet;
using System;
using UnityEngine;

namespace RossoGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
    public class PlayerScriptableObject : ScriptableObject
    {
        public MissileData missile;
        public PlayerData player;

        [Serializable]
        public class MissileData
        {
            public Missile missile;
            public int ammo;
            public float speed;
        }
        [Serializable]
        public class PlayerData
        {
            public GameObject explotionEffect;
            public float rotationSpeed;
            public float moveSpeed;
        }
    }
}