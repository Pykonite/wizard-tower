using UnityEngine;
using UnityEngine.UI;

namespace TowerHealth
{
    public class TowerHealth : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
        }
    }
}