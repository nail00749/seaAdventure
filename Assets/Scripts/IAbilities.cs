using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilities
{
    bool Using { get; }

    void UseAbility(GameObject Group, ObstacleChecker enemy, MoveController move);
}
