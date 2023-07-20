using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public double life = 40;
    public float speed = 5;

    public delegate void CollisionEvent(Bullet Bullet, Collider Collision);
    public event CollisionEvent OnCollsion;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.forward.normalized;
        rb.MovePosition(transform.position + speed * Time.deltaTime * direction);
        life -= Time.deltaTime;
        if(life < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + other.name);

        OnCollsion?.Invoke(this, other);
        OnCollsion = null;
 /*       if (other.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.ApplyDamage(damage);

            print("Detected collision between " + gameObject.name + " and " + other.name);
            //damageableObject.Damage(explosionDamage);
        }*/

    }
}
