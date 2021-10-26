using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLvL : MonoBehaviour
{

    public Module[] modules;
    public Module startModule;

    private List<Module> SpawnedModules; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnedModules = new List<Module>();
        SpawnedModules.Add(startModule);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnedModules.Count < 20)
        {
            CreateModule();
        }
    }

    private void CreateModule()
    {
            var newModule = Instantiate
                (modules[Random.Range(0, modules.Length - 1)]);
        newModule.transform.position =
          SpawnedModules[SpawnedModules.Count - 1].end.position - newModule.start.localPosition;
            SpawnedModules.Add(newModule);
    }
}
