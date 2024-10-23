using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition _uiCondition;

    Condition Health { get { return _uiCondition._health; } }
    Condition Hunger { get { return _uiCondition._hunger; } }
    Condition Stamina { get { return _uiCondition._stamina; } }

    public float _noHungerHealthDecay;

    void Update()
    {
        Hunger.Subtract(Hunger._passiveValue * Time.deltaTime);
        Stamina.Add(Stamina._passiveValue * Time.deltaTime);

        if(Hunger._curValue == 0f)
        {
            Health.Subtract(_noHungerHealthDecay * Time.deltaTime);
        }

        if (Health._curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        Health.Add(amount);
    }

    public void Eat(float amount)
    {
        Hunger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("ав╬З╢ы.");
    }
}
