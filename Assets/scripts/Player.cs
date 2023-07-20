using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public readonly string id;
    public Usable Usable;
    private Movement movement;

    public Transform UsablePosition1;
    //public Transform UsablePosition2;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
     if(Usable != null)
        {
            SetUsable(Usable);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(Usable != null)
            {
                Usable.StartUse();
            }
        }
    }


    public void SetUsable(Usable usable)
    {
        //TODO clean up existing Usable
        Usable = usable;
        usable.spawn(UsablePosition1);
        /*if (obj.TryGetComponent(out IUsable usable))
        {
            Usable = usable;
        }*/
    }
}
