using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Attack,
    Defense
}

public class powerup : MonoBehaviour
{
    [SerializeField] public string Description;
    //[SerializeField] public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class HealthBoost : powerup
{

}