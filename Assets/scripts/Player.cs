using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public readonly string id;
    public IUsable usable1;
    public IUsable usable2;
    public Movement movement;

    public Transform UsablePosition1;
    //public Transform UsablePosition2;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetUsable(GameObject obj)
    {
        if (obj.TryGetComponent(out IUsable usable))
        {
            usable1 = usable;
        }
    }
}
