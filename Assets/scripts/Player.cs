using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public readonly string id;
    public Usable Usable;
    private Movement movement;
    private Animator animator;
    public Transform UsablePosition1;
    //public Transform UsablePosition2;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
     if(Usable != null)
        {
            SetUsable(Usable);
        }   
    }

    private bool IsUsing()
    {
        return !animator.GetCurrentAnimatorStateInfo(0).IsName("meleeSwinging");// ||
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUsing())
        {

        }

        if(Input.GetKeyDown(KeyCode.E)) {
            if(Usable != null && Usable.CanUse())
            {
                if(Usable.usable.Usable == UsableType.MeleeWeapon)
                {
                    //movement.canMove = false;
                    animator.SetTrigger("startSwing");
                }else if(Usable.usable.Usable == UsableType.RangedWeapon)
                {
                    animator.SetTrigger("startRanged");
                }
                Usable.StartUse();
            }
        }
    }


    public void SetUsable(Usable usable)
    {
        //TODO clean up existing Usable
        usable.SpawnWithPlayer(UsablePosition1, this);
        Usable = usable;
    }
}
