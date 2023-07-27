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
    public bool InUse;
    //public Transform UsablePosition2;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
/*     if(Usable != null)
        {
            SetUsable(Usable);
        }   */
    }

/*    private bool IsUsing()
    {
        return !animator.GetCurrentAnimatorStateInfo(0).IsName("meleeSwinging");// ||
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
        {
            Debug.Log("done?");
        }*/

        if(Input.GetKeyDown(KeyCode.E)) {
            if(Usable != null && Usable.CanUse() && !InUse)
            {
                movement.canMove = false;
                InUse = true;
                if (Usable.usable.Usable == UsableType.MeleeWeapon)
                {
                    animator.SetTrigger("startSwing");
                }else if(Usable.usable.Usable == UsableType.RangedWeapon)
                {
                    animator.SetTrigger("startRanged");
                }
                //Usable.StartUse();
            }
        }
    }

    public void animationEvent(string data)
    {
        if(data == "done")
        {
            movement.canMove = true;
            InUse = false;
        }else if(data == "shoot")
        {
            Usable.StartUse();
        }
        Debug.Log(data);
    }

    public void SetUsable(Usable NewUsable)
    {
        if(Usable != null)
        {
            Usable.DestroyCurrentObject();
        }
        //TODO clean up existing Usable
        Usable = NewUsable;
        Usable.SpawnWithPlayer(UsablePosition1, this);
    }
}
