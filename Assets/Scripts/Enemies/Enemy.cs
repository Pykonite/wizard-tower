using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public new Transform transform;
        public float speed = 1;

        void Start()
        {
            transform = GetComponent<Transform>();
        }

        void Update()
        {
            transform.position= Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
        }
    }
}