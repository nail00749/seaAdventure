using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CreateLvL : MonoBehaviour
{

    public Module[] modules;
    public Module startModule;
    private List<Module> SpawnedModules;
    private Vector3 PositionHero;

    // Start is called before the first frame update
    void Start()
    {
        SpawnedModules = new List<Module>();
        SpawnedModules.Add(startModule);
        HeroManager.heroMoving += HeroManager_IsMoving;
    }

    private void HeroManager_IsMoving(Hero h)
    {
        PositionHero = h.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PositionHero.z < SpawnedModules[SpawnedModules.Count - 1].transform.position.z + 70)
        {
            CreateModule();
        }
    }

    private void CreateModule()
    {
        var newModule = Instantiate
            (modules[Random.Range(0, modules.Length - 1)]);
        
        var colliderOfModule = SpawnedModules[SpawnedModules.Count - 1].GetComponent<BoxCollider>();

        var pos = colliderOfModule.transform.position;

        newModule.transform.position = new Vector3(pos.x, pos.y, pos.z - colliderOfModule.size.z + 0.3f);
        SpawnedModules.Add(newModule);
        if (SpawnedModules.Count > 10)
        {
            Destroy(SpawnedModules[0].gameObject);
            SpawnedModules.RemoveAt(0);
        }
    }
}
