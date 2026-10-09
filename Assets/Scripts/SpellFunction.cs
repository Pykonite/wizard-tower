using UnityEngine;

public class SpellFunction : MonoBehaviour
{
public float life, damage;
private float lifetime;
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= life)
        {
            Destroy(gameObject);
        }
    }
}
