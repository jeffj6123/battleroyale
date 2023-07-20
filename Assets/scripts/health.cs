using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public string id;
    public double currentHealth = 100;
    public double maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        id = GetComponent<Player>().id;
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

public class Damage
{
    public int amount;
    public DamageType type;
    public string source;
    public Damage(int amount, DamageType type, string source)
    {
        this.amount = amount;
        this.type = type;
        this.source = source;
    }

}