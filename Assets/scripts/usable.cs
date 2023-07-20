using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    public void StartUse();

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

    public void spawn(Transform Parent)
    {
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(Parent, false);
        Model.transform.SetLocalPositionAndRotation(SpawnPoint, Quaternion.Euler(SpawnRotation));
        usable = Model.GetComponent<IUsable>();
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