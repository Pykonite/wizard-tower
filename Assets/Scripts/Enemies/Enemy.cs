using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public new Transform transform;
        public static readonly Vector2 Center = Vector2.zero;
        public float speed = 1;

        void Start()
        {
            transform = GetComponent<Transform>();
        }

        void Update()
        {
            transform.position= Vector2.MoveTowards(transform.position, Center, speed * Time.deltaTime);
        }
    }
}