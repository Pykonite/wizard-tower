using Enemies;
using TowerHealth
using UnityEngine.SceneManagement;

namespace PlayerInstance
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public TowerHealth healthbar;
        public int health, maxHealth = 100, round;
        public string gameOverScene;
        private void Start()
        {
            health = maxHealth;
            round = 0;
         //   healthbar.SetMaxHealth(maxHealth);
            GetComponent<Transform>().position = Vector3.zero;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(typeof(Enemy), out _)) return;
            TakeDamage(10);
            Destroy(other.gameObject);
            if (health <= 0) SceneManager.LoadScene(gameOverScene);
        }
        void TakeDamage(int damage)
        {
            health -= damage;
          //  healthbar.SetHealth(health);
        }
    }
}