using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private GameObject barrier;
    private Hero hero;
    private Collider heroCollider;
    private Collider barrierCollider;

    // Start is called before the first frame update
    void Start()
    {
        HeroManager.Created += HeroManager_Created;
        barrierCollider = barrier.GetComponent<BoxCollider>();
    }

    private void HeroManager_Created(Hero h)
    {
        hero = h;
        heroCollider = hero.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
