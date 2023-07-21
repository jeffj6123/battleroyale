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
    public void StartUse(Player player);

    public void EndUse();
}

[CreateAssetMenu(fileName = "Usable", menuName = "Usables/Usable", order = 0)]
public class Usable: ScriptableObject
{
    public string Name;
    public GameObject ModelPrefab;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
    private GameObject Model;
    private IUsable usable;
    private Player player;
    public void SpawnWithPlayer(Transform parent, Player player)
    {
        spawn(parent);
        usable = Model.GetComponent<IUsable>();
        this.player = player;
    }
 
    public void spawn(Transform Parent)
    {
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(Parent, false);
        Model.transform.SetLocalPositionAndRotation(SpawnPoint, Quaternion.Euler(SpawnRotation));
    }

    public void StartUse()
    {
        usable.StartUse(player);
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