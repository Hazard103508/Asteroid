using UnityEngine;
using UnityShared.Behaviours.Sprite;

namespace RossoGame.Environmet
{
    [RequireComponent(typeof(SpriteOutBoundsTrigger))]
    public class Wraparound : MonoBehaviour
    {
        private SpriteOutBoundsTrigger spriteOutBounds;

        private void Awake()
        {
            spriteOutBounds = GetComponent<SpriteOutBoundsTrigger>();
            spriteOutBounds.onOut.left.AddListener(MoveToRight);
            spriteOutBounds.onOut.right.AddListener(MoveToLeft);
            spriteOutBounds.onOut.top.AddListener(MoveToBottom);
            spriteOutBounds.onOut.bottom.AddListener(MoveToTop);
        }

        private void MoveToLeft() => transform.position = new Vector3(spriteOutBounds.BorderLeft, transform.position.y);
        private void MoveToRight() => transform.position = new Vector3(spriteOutBounds.BorderRight, transform.position.y);
        private void MoveToTop() => transform.position = new Vector3(transform.position.x, spriteOutBounds.BorderTop);
        private void MoveToBottom() => transform.position = new Vector3(transform.position.x, spriteOutBounds.BorderBottom);
    }
}