using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCreation : MonoBehaviour
{
    public Transform spawnBlock;
    public Hero[] heroes;
    public Hero hero;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        CreateHero();
        i++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeHero(i);
            i++;
            if (i > heroes.Length - 1)
            {
                i = 0;
            }
        }
    }

    public void CreateHero()
    {
        hero = Instantiate(heroes[i]);
        hero.transform.position = spawnBlock.position;
        hero.objectHero = hero.transform.gameObject;
        hero.objectHero.AddComponent<Rigidbody>();
        hero.objectHero.AddComponent<BoxCollider>();
        hero.objectHero.AddComponent<HeroMove>();
    }

    public void ChangeHero(int index)
    {
        var pos = hero.transform.position;
        Destroy(hero.objectHero);
        hero = Instantiate(heroes[index]);
        hero.transform.position = pos;
        hero.objectHero.AddComponent<Rigidbody>();
        hero.objectHero.AddComponent<BoxCollider>();
        hero.objectHero.AddComponent<HeroMove>();
    }

}
