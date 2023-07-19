using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] Damage damage = new Damage(10, DamageType.Bullet);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
  
        if (collisionInfo.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.ApplyDamage(damage);

            print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
            print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
            print("Their relative velocity is " + collisionInfo.relativeVelocity);
            //damageableObject.Damage(explosionDamage);
        }

    }
}
