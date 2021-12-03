using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateLvL : MonoBehaviour
{

    public Module[] modules;
    public Module startModule;
    private List<Module> SpawnedModules;
    public GameObject HeroGroup;

    void Start()
    {
        SpawnedModules = new List<Module>();
        SpawnedModules.Add(startModule);
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroGroup.transform.position.z > SpawnedModules[SpawnedModules.Count - 1].transform.position.z - 100)
        {
            CreateModule();
        }
    }

    private void CreateModule()
    {
        
        var newModule = NextModule();
        var colliderOfModule = SpawnedModules[SpawnedModules.Count - 1].GetComponent<BoxCollider>();

        var pos = colliderOfModule.transform.position;

        newModule.transform.position = new Vector3(pos.x, pos.y, pos.z + colliderOfModule.size.z);
        SpawnedModules.Add(newModule);
        if (SpawnedModules.Count > 8)
        {
            Destroy(SpawnedModules[0].gameObject);
            SpawnedModules.RemoveAt(0);
        }
    }

    private Module NextModule()
    {
        var module = SpawnedModules[SpawnedModules.Count - 1];
        Module newModule = null;
        if(module.GetComponentInChildren<Enemy>() != null)
        {
            newModule = Instantiate
            (modules[Random.Range(0, 6)]);
        }
        else
        {
            newModule = Instantiate
            (modules[Random.Range(0, modules.Length - 1)]);
        }
        return newModule;
    }
}
