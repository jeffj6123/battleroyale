using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponSpawner : MonoBehaviour
{

    
    [SerializeField] List<Usable> usables = new();
    [SerializeField] Transform SpawnPosition;
    GameObject currentUsable;
    Usable usable;
    float respawonCooldown = 5f;
    float currentCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(currentUsable == null)
        {
            if(currentCooldown <= 0)
            {
                usable = usables[0];
                currentUsable = usable.Spawn(SpawnPosition);
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }
        }

        SpawnPosition.transform.Rotate(new Vector3(0, 25 * Time.deltaTime, 0));
        SpawnPosition.transform.localPosition = new Vector3(SpawnPosition.transform.localPosition.x, 1f + .2f * Mathf.Sin(Time.time), 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(currentUsable != null && other.TryGetComponent(out Player player))
        {
            player.SetUsable(Instantiate(usable));
            Destroy(currentUsable);
            currentCooldown = respawonCooldown;
        }
    }
}
