using UnityEngine;
using UnityEngine.InputSystem;
public class CastSpells : MonoBehaviour
{
    public InputAction castSpellAction, one, two, three, four, five, up, down, drop;
    public GameObject spellone, spelltwo, spellthree, spellfour, spellfive;
    public ManaBar manaBar;
    public int mana, maxMana = 10;
    public static int Spell;
    private float manaRegenTimer = 0;
    public float manaRegenInterval;
    void Start()
    {
        Spell = 0;
        castSpellAction.Enable();
        one.Enable();
        two.Enable();
        three.Enable();
        four.Enable();
        five.Enable();
        up.Enable();
        down.Enable();
        drop.Enable();
        mana = maxMana;
        manaBar.SetMaxMana(maxMana);
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
            if (Spell > 5) Spell = 0;
        }
        if (down .IsPressed())
        {
            Spell--;
            if (Spell < 0) Spell = 5;
        }
        if (castSpellAction.WasPressedThisFrame()) switch (Spell)
        {
            case 1: if (mana-1>=0) {Instantiate(spellone, transform.position, transform.rotation); TakeMana(1);} break;
            case 2: if (mana-3>=0) {Instantiate(spelltwo, transform.position, transform.rotation); TakeMana(3);} break;
            case 3: if (mana-3>=0) {Instantiate(spellthree, transform.position, transform.rotation); TakeMana(3);} break;
            case 4: if (mana-2>=0) {Instantiate(spellfour, transform.position, transform.rotation); TakeMana(2);} break;
            case 5: if (mana-10>=0) {Instantiate(spellfive, transform.position, transform.rotation); TakeMana(10);} break;
        }
        manaRegenTimer += Time.deltaTime;
        if (manaRegenTimer >= manaRegenInterval)
        {
            manaRegenTimer = 0;
            if (mana < maxMana)
            {
                mana++;
                manaBar.SetMana(mana);
            }
        }
    }
    void TakeMana(int cost)
    {
        mana -= cost;
        manaBar.SetMana(mana);
    }
}
