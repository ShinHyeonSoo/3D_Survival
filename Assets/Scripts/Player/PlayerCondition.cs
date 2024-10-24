using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition _uiCondition;

    Condition Health { get { return _uiCondition._health; } }
    Condition Hunger { get { return _uiCondition._hunger; } }
    Condition Stamina { get { return _uiCondition._stamina; } }

    public float _noHungerHealthDecay;

    public event Action OnTakeDamage;

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

    public void TakePhysicalDamage(int damage)
    {
        Health.Subtract(damage);
        OnTakeDamage?.Invoke();
    }
    
    public bool UseStamina(float amount)
    {
        if(Stamina._curValue - amount < 0f)
        {
            return false;
        }

        Stamina.Subtract(amount);
        return true;
    }
}
