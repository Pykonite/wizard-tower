using UnityEngine;
public class Highlight : MonoBehaviour
{ 
    public float Spell, Count;

    void Update()
    {
        Spell = CastSpells.Spell;
        if (Spell == Count) {GetComponent<Renderer>().material.color = Color.blue;}
        else {GetComponent<Renderer>().material.color = Color.white;}
    }
}
