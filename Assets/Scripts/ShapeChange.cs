using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    public SpriteRenderer Shape;
    public Sprite one, two, three, four, five;
    private int spell;
    void Update()
    {
        spell = CastSpells.Spell;
        switch (spell)
        {
            case 1:
                Shape.sprite = one;
                break;
            case 2:
                Shape.sprite = two;
                break;
            case 3:
                Shape.sprite = three;
                break;
            case 4:
                Shape.sprite = four;
                break;
            case 5:
                Shape.sprite = five;
                break;
        }
    }
}
