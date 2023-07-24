using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IUsable
{
    public Player player { get; set; }
    public UsableType Usable { get { return UsableType.MeleeWeapon; } set { } }

    bool swinging = false;

    public void Init(Player player)
    {
        this.player = player;
    }
    public void EndUse()
    {
        this.swinging = false;
    }

    public bool CanUse()
    {
        return true;
    }

    public void StartUse()
    {
        this.swinging = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (swinging)
        {
            Debug.Log("bang bang" + other.name);
        }
    }
}
