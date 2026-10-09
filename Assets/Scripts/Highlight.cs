using UnityEngine;
public class Highlight : MonoBehaviour
{ 
    public int spell, count;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        spell = CastSpells.Spell;
        _renderer.material.color = spell == count ? Color.blue : Color.white;
    }
}
