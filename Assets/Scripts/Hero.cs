using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private string heroName;    

    public string GetHeroName
    {
        get {return heroName;}
    }
}
