using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����� �������� �����
/// ������������ ��������, �����, �������� ���������
/// </summary>
public class HeroManager : MonoBehaviour
{
    public delegate void CreateHeroDelegate(Hero h);
    /// <summary>
    /// ������� �������� �����
    /// </summary>


    /// <summary>
    /// ������� ����������� �����
    /// </summary>

    #region ����
    public static event CreateHeroDelegate Created;
    public static event CreateHeroDelegate heroMoving;
    public Transform spawnBlock;
    public Hero[] heroes;
    private Hero hero;
    private int i;
    private bool isMoving;
    private Vector3 TargetPosition;
    private float speed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        CreateHero();
        i++;

        isMoving = false;
        speed = 5f;
        ClickHandler.IsClicked += Click_IsClicked;
        CollisionManager.CollisionEnter += CollisionManager_CollisionEnter;
    }

    private void CollisionManager_CollisionEnter(GameObject gameObject)
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //����� ��������� �� ������� ������ Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeHero();
            i++;
            if (i > heroes.Length - 1)
            {
                i = 0;
            }
        }
        //������� ���������
        if (isMoving)
        {
            Move();
        }
    }

    /// <summary>
    /// ����� ��������� �����
    /// </summary>
    public void CreateHero(Vector3 position = new Vector3())
    {
        hero = Instantiate(heroes[i]);
        if (position != new Vector3(0,0,0))
            hero.transform.position = position;
        else
            hero.transform.position = spawnBlock.position;
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


    /// <summary>
    /// ����� ��������� ��������� ����� 
    /// ������� ������� �� ��������� ���� �������
    /// </summary>
    /// <param name="args"></param>
    private void Click_IsClicked(Vector3 args)
    {
        Ray ray = Camera.main.ScreenPointToRay(args);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            TargetPosition = hit.point;
        }
        //���������
        //������������ �� ��� ��������
        hero.transform.LookAt(TargetPosition);

        isMoving = true;
    }


    /// <summary>
    /// ����� �������� ������
    /// </summary>
    private void Move()
    {
        hero.transform.position = Vector3.MoveTowards
            (hero.transform.position, TargetPosition, speed * Time.deltaTime);
        heroMoving?.Invoke(hero);

        if ((int)(hero.transform.position.x) == (int)(TargetPosition.x) 
            && (int)(hero.transform.position.z) == (int)(TargetPosition.z))
        {
            isMoving = false;
        }

    }
}
