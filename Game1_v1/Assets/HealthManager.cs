using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public Slider slider;


        private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        slider.value =  maxhealth;   
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

     
}
