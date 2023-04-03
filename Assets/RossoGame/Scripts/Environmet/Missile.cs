using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RossoGame.Environmet
{
    public class Missile : MonoBehaviour
    {
        public float speed;

        public void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}