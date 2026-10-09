using UnityEngine;
using UnityEngine.InputSystem;
public class CastSpells : MonoBehaviour
{
    public InputAction castSpellAction, one, two, three, four, five, up, down, drop;
    public GameObject spellone, spelltwo, spellthree, spellfour, spellfive;
    public static int Spell;
    void Start()
    {
        castSpellAction.Enable();
        one.Enable();
        two.Enable();
        three.Enable();
        four.Enable();
        five.Enable();
        up.Enable();
        down.Enable();
        drop.Enable();
    }

    void Update()
    {
        if (drop .IsPressed()) Spell = 0;
        if (one  .IsPressed()) Spell = 1;
        if (two  .IsPressed()) Spell = 2;
        if (three.IsPressed()) Spell = 3;
        if (four .IsPressed()) Spell = 4;
        if (five .IsPressed()) Spell = 5;
        if (up.IsPressed())
        {
            Spell++;
            if (Spell > 5) Spell = 1;
        }
        if (down .IsPressed())
        {
            Spell--;
            if (Spell < 1) Spell = 5;
        }
        if (castSpellAction.WasPressedThisFrame()) switch (Spell)
        {
            case 1: Instantiate(spellone, transform.position, transform.rotation); break;
            case 2: Instantiate(spelltwo, transform.position, transform.rotation); break;
            case 3: Instantiate(spellthree, transform.position, transform.rotation); break;
            case 4: Instantiate(spellfour, transform.position, transform.rotation); break;
            case 5: Instantiate(spellfive, transform.position, transform.rotation); break;
        }
    }
}
