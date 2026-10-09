using System;
using Enemies;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace PlayerInstance
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public int health, maxHealth, mana, maxMana, round;
        public string gameOverScene;
        private void Start()
        {
            health = maxHealth;
            mana = maxMana;
            round = 0;
            GetComponent<Transform>().position = Vector3.zero;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(typeof(Enemy), out _)) return;
            health--;
            Destroy(other.gameObject);
            if (health <= 0) SceneManager.LoadScene(gameOverScene);
        }
    }
}