using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IUsable
{
    public GameObject bullet;
    //[SerializeField] Bullet bullet;
    public int maxAmmo = 10;
    int currentAmmo = 10;
    double cooldown = 1;
    double currentCooldown = 0;
    public void EndUse()
    {
        
    }

    public void StartUse()
    {
        if(currentCooldown < 0 && currentAmmo > 0)
        {
            Fire();
        }
    }

    public void Fire()
    {
        currentAmmo -= 1;
        currentCooldown -= cooldown;
        Instantiate(bullet);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
