using UnityEngine;
using UnityEngine.InputSystem;
public class CastSpells : MonoBehaviour
{
    public InputAction castSpellAction, one, two, three, four, five;
    public GameObject spellone, spelltwo, spellthree, spellfour, spellfive;
    public static int Spell;
    void Start()
    {
        Spell = 0;
        castSpellAction.Enable();
        one.Enable();
        two.Enable();
        three.Enable();
        four.Enable();
        five.Enable();
    }
    void Update()
    {
        if (one.IsPressed()) {Spell = 1;}
        if (two.IsPressed()) {Spell = 2;}
        if (three.IsPressed()) {Spell = 3;}
        if (four.IsPressed()) {Spell = 4;}
        if (five.IsPressed()) {Spell = 5;}
        if (castSpellAction.WasPressedThisFrame())
        {
            if (Spell == 1) {Instantiate(spellone, transform.position, transform.rotation);}
            if (Spell == 2) {Instantiate(spelltwo, transform.position, transform.rotation);}
            if (Spell == 3) {Instantiate(spellthree, transform.position, transform.rotation);}
            if (Spell == 4) {Instantiate(spellfour, transform.position, transform.rotation);}
            if (Spell == 5) {Instantiate(spellfive, transform.position, transform.rotation);}
        }
    }
}
