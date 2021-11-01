using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Animator Shake;
    private Vector3 Offset;
    private Vector3 PositionHero;
    private List<GameObject> enemyObjects;

    // Start is called before the first frame update
    void Start()
    {
        enemyObjects = new List<GameObject>();
        HeroManager.Created += HeroManager_Created;
        HeroManager.heroMoving += HeroManager_IsMoving;
        CollisionManager.CollisionEnter += ShakeCamera;
    }

    private void ShakeCamera(GameObject gameObject)
    {
        if(!enemyObjects.Contains(gameObject))
        {
            enemyObjects.Add(gameObject);
            Shake.SetTrigger("Shake");
        }
        
    }

    private void HeroManager_IsMoving(Hero hero)
    {
        PositionHero = hero.transform.position;
    }

    /// <summary>
    /// ����� ����������� ���������� �� ������ �� �����
    /// ����������� ����� ������� ��������� ���������
    /// </summary>
    /// <param name="hero"></param>
    private void HeroManager_Created(Hero hero)
    {
        PositionHero = hero.transform.position;
        Offset = transform.position - PositionHero;
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = PositionHero + Offset;
        for (var i = 0; i < enemyObjects.Count - 1; i++)
        {
            var enemy = enemyObjects[i];
            if(PositionHero.z < enemy.transform.position.z + 20 || 
               PositionHero.z > enemy.transform.position.z - 20)
            {
                enemyObjects.RemoveAt(i);
                Debug.Log("Remove");
            }
        }
    }

}
