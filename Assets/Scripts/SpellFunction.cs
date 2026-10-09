using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class SpellFunction : MonoBehaviour
{
    public enum SpellType {OneShot, Tick, Both}
    public float life, instDamage, tickDamage;
    private float _lifetime;
    public SpellType spellType;
    public Rigidbody2D rb;
    private List<Enemy> _collisions;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Enemy), out var appender))
        {
            _collisions.Add(appender as Enemy);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(typeof(Enemy), out var appender))
        {
            _collisions.Remove(appender as Enemy);
        }
    }


    private void Start()
    {
        if (spellType == SpellType.Tick) return;
        foreach (var target in _collisions)
        {
            target.health -= instDamage;
        }
    }
    void Update()
    {
        _lifetime += Time.deltaTime;
        foreach (var target in _collisions)
        {
            target.health -= tickDamage;
        }
        if (_lifetime >= life)
        {
            Destroy(gameObject);
        }
    }
}
