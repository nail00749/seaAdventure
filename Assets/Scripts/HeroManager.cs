using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroManager : MonoBehaviour
{
    public delegate void CreateHeroDelegate(Hero h);

    #region поля
    public static event CreateHeroDelegate Created;
    public static event CreateHeroDelegate heroMoving;
    public Transform SpawnBlock;
    public Hero[] Heroes;
    private Hero hero;
    private int i;
    private bool IsMoving;
    private bool Turns;
    private Vector3 TargetPosition;
    private Vector3 PrevHeroPosition;
    private float Speed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        CreateHero();
        i++;

        IsMoving = false;
        Turns = false;
        Speed = 5f;
        ClickHandler.IsClicked += Click_IsClicked;
        CollisionManager.CollisionEnter += CollisionManager_CollisionEnter; 
    }

    private void CollisionManager_CollisionEnter(GameObject gameObject)
    {
        IsMoving = false;
        Turns = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeHero();
            i++;
            if (i > Heroes.Length - 1)
            {
                i = 0;
            }
        }

        if (Turns)
        {
            
            HeroTurn();

        }

        if (IsMoving)
        {
            Move();
        }
    }

    /// <summary>
    /// ����� ��������� �����
    /// </summary>
    public void CreateHero(Vector3 position = new Vector3())
    {
        hero = Instantiate(Heroes[i]);
        if (position != new Vector3(0,0,0))
            hero.transform.position = position;
        else
            hero.transform.position = SpawnBlock.position;
        hero.gameObject.AddComponent<Rigidbody>();
        hero.gameObject.AddComponent<BoxCollider>();
        hero.gameObject.AddComponent<CollisionManager>();

        Created?.Invoke(hero);
    }
    /// <summary>
    /// ����� �������� ������
    /// ������� ������� � ������� ������
    /// </summary>
    public void ChangeHero()
    {
        var pos = hero.transform.position;
        Destroy(hero.gameObject);
        CreateHero(pos);
    }


    private void Click_IsClicked(Vector3 args)
    {
        Ray ray = Camera.main.ScreenPointToRay(args);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            TargetPosition = hit.point;
        }

        Turns = true;
    }

    private void HeroTurn()
    {
        Vector3 direction = (TargetPosition - hero.transform.position);
        Quaternion rotation = Quaternion.LookRotation(-direction);
        hero.transform.rotation = Quaternion.Slerp(hero.transform.rotation, rotation, Speed * Time.deltaTime);
        
        float angleHero = (float)Math.Round(hero.transform.rotation.y, 3);
        float anglePoint = (float)Math.Round(rotation.y, 3);
        
        anglePoint = anglePoint > 0 ? anglePoint : -anglePoint;
        angleHero = angleHero > 0 ? angleHero : -angleHero;

        if (anglePoint == angleHero)
        {
            IsMoving = true; 
            Turns = false;
        }
    }


    private void Move()
    {
        hero.transform.position = Vector3.MoveTowards
            (hero.transform.position, TargetPosition, Speed * Time.deltaTime);
        heroMoving?.Invoke(hero);

        if ((int)(hero.transform.position.x) == (int)(TargetPosition.x) 
            && (int)(hero.transform.position.z) == (int)(TargetPosition.z))
        {
            IsMoving = false;
        }

    }

}
