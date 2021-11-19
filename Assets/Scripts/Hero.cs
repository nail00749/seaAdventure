using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    
    public string heroName;

    public void SawAbility()
    {
        Debug.Log("Способность пилы");
    }
    public void TurtlesAbility()
    {
        Debug.Log("Способность черепахи");
    }
    public void HedgehogAbility()
    {
        Debug.Log("Способность ежа");
    }
    public void EelAbility()
    {
        Debug.Log("Способность угря");
    }
    public void HammerAbility()
    {
        Debug.Log("Способность молота");
    }
}
