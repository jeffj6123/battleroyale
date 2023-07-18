using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
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

    void applyDamage(double damage) {
        //TODO apply modifications 
        this.currentHealth -= damage;

        if(this.currentHealth < 0) {
            //TODO report to game manager
        }
    }
}
