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
        if (spell == 1)                 {transform.localScale = new Vector3(1, 1, 1);}
        if (spell == 2 || spell == 3)   {transform.localScale = new Vector3(4, 4, 1);}
        if (spell == 4)                 {transform.localScale = new Vector3(2, 2, 1);}
        if (spell == 5)                 {transform.localScale = new Vector3(6, 6, 1);}
    }
}
