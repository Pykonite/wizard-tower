using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyInstancer : MonoBehaviour
    { 
        public float boundsRadius = 6;
        private float _spawnTimer;
        public float spawnTimeMin = 2;
        public float spawnTimeMax = 10;
        public List<GameObject> enemyTypes;
        void Update()
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0) Spawn();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        void Spawn()
        {
            Debug.Log("Spawning Enemy");
            _spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
            var enemyObject = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)]);
            var pos = new Vector2(0, 0);
            switch (Random.Range(0, 4))
            {
                case 0: 
                    pos.x = -boundsRadius; 
                    pos.y = Random.Range(-boundsRadius, boundsRadius);
                    break;
                case 1: 
                    pos.x =  boundsRadius; 
                    pos.y = Random.Range(-boundsRadius, boundsRadius);
                    break;
                case 2: 
                    pos.y = -boundsRadius; 
                    pos.x = Random.Range(-boundsRadius, boundsRadius);
                    break;
                case 3: 
                    pos.y =  boundsRadius; 
                    pos.x = Random.Range(-boundsRadius, boundsRadius);
                    break;
            }
            enemyObject.GetComponent<Enemy>().transform.position = new Vector2(pos.x + Enemy.Center.x, pos.y + Enemy.Center.y);
        }
    }
}