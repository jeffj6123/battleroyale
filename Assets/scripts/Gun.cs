using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IUsable
{
    public GameObject Bullet;
    public Transform launchPosition;
    public Player player { get; set; }
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
        if(currentCooldown <= 0 && currentAmmo > 0)
        {
            Fire();
        }
    }

    public void Fire()
    {
        currentAmmo -= 1;
        currentCooldown = cooldown;
        var bullet = Instantiate(Bullet);
        bullet.transform.SetPositionAndRotation(launchPosition.position, launchPosition.rotation);
        bullet.GetComponent<Bullet>().OnCollsion += HandleBulletCollision;
    }

    private void HandleBulletCollision(Bullet Bullet, Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.ApplyDamage(new Damage(10, DamageType.Bullet, player.id));

            print("Detected collision between " + gameObject.name + " and " + other.name);
            //damageableObject.Damage(explosionDamage);
        }

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
