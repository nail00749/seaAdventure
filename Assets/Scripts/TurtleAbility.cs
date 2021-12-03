using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleAbility :  MonoBehaviour, IAbilities 
{
    private bool isUsing;

    public bool Using
    {
        get{return isUsing;}
    }

    public  void UseAbility(GameObject Group, ObstacleChecker enemy, MoveController move)
    {
        isUsing = false;
    }
}
