using Enemies;
using UnityEngine.SceneManagement;

namespace PlayerInstance
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public TowerHealth healthBar;
        public int health, maxHealth = 100, round;
        public string gameOverScene;
        private void Start()
        {
            health = maxHealth;
            round = 0;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(typeof(Enemy), out var component)) return;
            var enemy = component as Enemy;
            TakeDamage(Mathf.CeilToInt(enemy!.health));
            Destroy(other.gameObject);
            if (health <= 0) SceneManager.LoadScene(gameOverScene);
        }
        void TakeDamage(int damage)
        {
            health -= damage;
            healthBar.SetHealth(health);
        }
    }
}