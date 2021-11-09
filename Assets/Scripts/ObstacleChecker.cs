using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleChecker : MonoBehaviour
{   
    public MoveController heroGroupMoveController;
    public Text textObstacle;
    public List<GameObject> Heroes;
    private Dictionary<string, GameObject> passingDict;
    public HeroChanger heroGroupHeroChanger;
    public Button UseAbilityButton;
    public Button ChangeHeroButton;

    void Start()
    {
        passingDict = new Dictionary<string, GameObject>();
        passingDict.Add("saw", Heroes[1].gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "obstacle")
        {
            heroGroupMoveController._isMove = false;

            var type = other.GetComponent<Enemy>().passingObject;
            var currentHero = Heroes[heroGroupHeroChanger.GetActiveHeroIndex].gameObject;
            if (passingDict[type] == currentHero)
                UseAbilityButton.gameObject.SetActive(true);
            else
                ChangeHeroButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textObstacle.text = "";
        UseAbilityButton.gameObject.SetActive(false);
        ChangeHeroButton.gameObject.SetActive(false);
    }
}