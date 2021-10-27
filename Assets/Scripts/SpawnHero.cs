using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    public Transform spawnBlock;
    public Hero[] heroes;

    // Start is called before the first frame update
    void Start()
    {
        CreateHero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateHero()
    {
        var rnd = new System.Random();
        var newHero = Instantiate(heroes[rnd.Next(0,heroes.Length-1)]);
        newHero.transform.position = spawnBlock.position;
    }

}
