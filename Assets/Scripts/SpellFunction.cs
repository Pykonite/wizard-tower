using System.Collections.Generic;
using System.Linq;
using Enemies;
using UnityEngine;

public class SpellFunction : MonoBehaviour
{
    public enum SpellType {OneShot, Tick, Both}
    public float life, instDamage, tickDamage;
    private float _lifetime;
    public SpellType spellType;
    public new Collider2D collider2D;
    public float delay;
    // ReSharper disable Unity.PerformanceAnalysis
    private List<Enemy> _collisions()
    {
        var filter = new ContactFilter2D
        {
            useTriggers = true
        };
        var list = new List<Collider2D>();
        collider2D.Overlap(filter, list);
        if (list.Count != 1 || !list[0].gameObject.TryGetComponent(typeof(Realter), out var component))
            return list.Select(collided => collided.gameObject.GetComponent<Enemy>()).ToList();
        var realter = component as Realter;
        realter!.Finished();
        return list.Select(collided => collided.gameObject.GetComponent<Enemy>()).ToList();
    }

    private void Start()
    {
        Invoke(nameof(Collision), delay);
    }
    private void Collision()
    {
        collider2D = GetComponent<Collider2D>();
        if (spellType == SpellType.Tick) return;
        foreach (var target in _collisions().Where(target => target))
        {
            target.health -= instDamage;
        }
    }
    void Update()
    {
        _lifetime += Time.deltaTime;
        foreach (var target in _collisions().Where(target => target))
        {
            target.health -= tickDamage * Time.deltaTime;
        }
        if (_lifetime >= life)
        {
            Destroy(gameObject);
        }
    }
}
