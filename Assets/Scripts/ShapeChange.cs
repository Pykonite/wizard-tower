using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    public SpriteRenderer shape;
    public Sprite zero, one, two, three, four, five;
    private int _spell;
    void Update()
    {
        _spell = CastSpells.Spell;
        shape.sprite = _spell switch
        {
            0 => zero,
            1 => one,
            2 => two,
            3 => three,
            4 => four,
            5 => five,
            _ => shape.sprite
        };
        if (_spell == 1 || _spell == 0)  {transform.localScale = new Vector3(1, 1, 1);}
        if (_spell == 2 || _spell == 3)  {transform.localScale = new Vector3(4, 4, 1);}
        if (_spell == 4)                 {transform.localScale = new Vector3(2, 2, 1);}
        if (_spell == 5)                 {transform.localScale = new Vector3(6, 6, 1);}
    }
}
