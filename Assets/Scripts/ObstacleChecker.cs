using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleChecker : MonoBehaviour
{
    public MoveController heroGroupMoveController;
    public Text textObstacle;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "obstacle")
        {
            heroGroupMoveController._isMove = false;
            textObstacle.text = "Здесь препяствие";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textObstacle.text = "";
    }
}