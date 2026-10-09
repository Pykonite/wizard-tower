using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    public SpriteRenderer Shape;
    public Sprite one, two, three, four, five;
    private int spell;
    void Update()
    {
        spell = CastSpells.Spell;
        Shape.sprite = spell switch
        {
            0 => null,
            1 => one,
            2 => two,
            3 => three,
            4 => four,
            5 => five,
            _ => Shape.sprite
        };
    }
}
