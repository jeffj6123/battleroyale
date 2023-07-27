using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum  UsableType
{
    Potion,
    MeleeWeapon,
    RangedWeapon
}

public interface IUsable
{
    //TODO consider moving this?

    public UsableType Usable { get; set; }
    public void StartUse();

    public void EndUse();

    public bool CanUse();

    public void Init(Player player);
}

[CreateAssetMenu(fileName = "Usable", menuName = "Usables/Usable", order = 0)]
public class Usable: ScriptableObject
{
    public string Name;
    public GameObject ModelPrefab;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
    private GameObject Model;
    public IUsable usable;
    public void SpawnWithPlayer(Transform parent, Player player)
    {
        Spawn(parent);
        usable = Model.GetComponent<IUsable>();
        usable.Init(player);
    }

    public GameObject Spawn(Transform Parent)
    {
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(Parent, false);
        Model.transform.SetLocalPositionAndRotation(SpawnPoint, Quaternion.Euler(SpawnRotation));
        return Model;
    }

    public void DestroyCurrentObject()
    {
        if (Model != null)
        {
            Model.SetActive(false);
            Destroy(Model);
        }
    }

    public bool CanUse()
    {
        return true;// Model && usable.CanUse();
    }

    public void StartUse()
    {
        usable.StartUse();
    }

    public void EndUse()
    {
        usable.EndUse();
    }


    public void OnValidate()
    {
        if (!ModelPrefab.TryGetComponent<IUsable>(out _))
        {
            Debug.LogWarning(ModelPrefab.name + "does not implement IUsable");
        }
    }

}

public class GunUsable : Usable
{

}