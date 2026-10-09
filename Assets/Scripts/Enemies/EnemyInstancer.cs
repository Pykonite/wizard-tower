using System.Collections.Generic;
using System.Linq;
using PlayerInstance;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyInstancer : MonoBehaviour
    { 
        public float boundsRadius = 8;
        public List<GameObject> enemyTypes;
        private int _groups = 3;
        private float _groupSize = 1;
        private float _evolution;
        private const float SpacingMultiplier = 0.5f;
        public Player player;
        private List<GameObject> _enemiesLeft;
        private bool _isRunning;
        public TextMeshProUGUI waveCounter;
        // Temporary. Replace with hook from tutorial.
        public void SpawnEnemies()
        {
            waveCounter.text = "Wave: " + player.round;
            for ( var i = 0; i < _groups; i++ )
            {
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

                pos *= Random.Range(1, 1.2f);
                var placed = new Vector2[GroupSize()];
                var objects = new GameObject[placed.Length];
                Debug.Log(placed .Length);
                Debug.Log(objects.Length);
                for (var j = 0; j < objects.Length; j++)
                {
                    var instance = EnemyType();
                    instance.transform.position = pos;
                    objects[j] = instance;
                    placed[j] = new Vector2(
                        Random.Range(0, SpacingMultiplier * objects.Length), 
                        Random.Range(0, SpacingMultiplier * objects.Length));
                }
                placed = SpaceOut(placed);
                for (var j = 0; j < objects.Length ; j ++ )
                {
                    var position = objects[j].GetComponent<Transform>().position;
                    position.x += placed[j].x - SpacingMultiplier * objects.Length / 2;
                    position.y += placed[j].y - SpacingMultiplier * objects.Length / 2;
                    objects[j].GetComponent<Transform>().position = position;
                }
                _enemiesLeft = objects.ToList();
                _isRunning = true;
            }
        }
        private void Update()
        {
            if (_enemiesLeft is { Count: > 0 }) 
                foreach (var e in _enemiesLeft.ToList()
                             .Where(e => !e.gameObject)) 
                    _enemiesLeft.Remove(e);
            else if (_isRunning)
            {
                _isRunning = false;
// ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                RoundEnd();
            }
        }

        private static Vector2[] SpaceOut(Vector2[] positions, int iter = 0)
        {
            if (iter > 12) return positions; 
            for (var i = 0; i < positions.Length; i++)
            {
                for (var j = 0; j < positions.Length; j++)
                {
                    if (i == j) continue;
                    var displacement = positions[i] - positions[j];
                    if (!(displacement.magnitude <= SpacingMultiplier)) continue;
                    positions[i] = new Vector2(
                        Random.Range(0, SpacingMultiplier * positions.Length),
                        Random.Range(0, SpacingMultiplier * positions.Length));
                    break;
                }

                if (positions.Where((t, j) => i != j)
                    .Select(t => positions[i] - t)
                    .Any(displacement => displacement.magnitude <= SpacingMultiplier))
                {
                    return SpaceOut(positions, iter + 1);
                }
            }
            return positions;
        }

        private int GroupSize()
        {
            return Mathf.RoundToInt(Random.Range(_groupSize - _groupSize / 2, _groupSize + _groupSize / 2));
        }

        private GameObject EnemyType()
        {
            var evo = Mathf.CeilToInt(Random.Range(0, _evolution));
            if (evo >= enemyTypes.Count) evo = enemyTypes.Count - 1;
            if (evo >= player.round / 5) evo = Mathf.FloorToInt(player.round / 5f);
            return Instantiate(enemyTypes[evo]);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void RoundEnd()
        {
            player.round += 1;
            switch (Random.Range(0, 3))
            {
                case 0: _groupSize *= 1.15f; break;
                case 1: _groups += 2; break;
                case 2: _evolution += 0.2f; break;
            }
            // Add await for player selection
            Invoke(nameof(SpawnEnemies), 5f);
        }
    }
}