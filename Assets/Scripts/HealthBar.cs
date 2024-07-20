using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(int health)
    {
        slider.value = health;
    }
}
