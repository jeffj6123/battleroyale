using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

    public double currentHealth = 100;
    public double maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(Damage damage)
    {
        //TODO apply modifications 
        this.currentHealth -= damage.amount;

        if (this.currentHealth < 0)
        {
            //TODO report to game manager
        }
    }

}

public interface IDamageable
{
    public void ApplyDamage(Damage damage);
}

public enum DamageType
{
    Melee,
    Bullet,
    Fire
}

public struct Damage
{
    public int amount;
    public DamageType type;

    public Damage(int amount, DamageType type)
    {
        this.amount = amount;
        this.type = type;
    }

}