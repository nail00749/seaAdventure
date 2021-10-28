using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLvL : MonoBehaviour
{

    public Module[] modules;
    public Module startModule;

    private List<Module> SpawnedModules; 

    public List<Module> GetSpawnedModules
    {
        get { return SpawnedModules; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnedModules = new List<Module>();
        SpawnedModules.Add(startModule);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnedModules.Count < 40)
        {
            CreateModule();
        }
    }

    private void CreateModule()
    {
            var newModule = Instantiate
                (modules[Random.Range(0, modules.Length - 1)]);
        #region Первый способ генерации уровня
        //newModule.transform.position =
        //SpawnedModules[SpawnedModules.Count - 1].end.position - newModule.start.localPosition;
        #endregion
        #region Второй способ генерации уровня
        var posX = SpawnedModules[SpawnedModules.Count - 1].module.transform.position.x;
        var posY = SpawnedModules[SpawnedModules.Count - 1].module.transform.position.y;
        var posZ = SpawnedModules[SpawnedModules.Count - 1].module.transform.position.z;
        #endregion
        newModule.transform.position = new Vector3(posX, posY, posZ - 21f);
          SpawnedModules.Add(newModule);
        //newModule.module = newModule.transform.gameObject;
    }
}
