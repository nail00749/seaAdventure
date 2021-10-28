using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Класс менеджер героя
/// Обрабатывает создание, смену, движение персонажа
/// </summary>
public class HeroManager : MonoBehaviour
{
    public delegate void CreateHeroDelegate(Hero h);
    /// <summary>
    /// Событие создания героя
    /// </summary>


    /// <summary>
    /// Событие перемещения героя
    /// </summary>

    #region Поля
    public static event CreateHeroDelegate Created;
    public static event CreateHeroDelegate IsMoving;
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
    }

    // Update is called once per frame
    void Update()
    {
        //Смена персонажа по нажатию кнопки Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeHero();
            i++;
            if (i > heroes.Length - 1)
            {
                i = 0;
            }
        }
        //Дижение персонажа
        if (isMoving)
        {
            Move();
        }
    }

    /// <summary>
    /// Метод создающий героя
    /// </summary>
    public void CreateHero(Vector3 position = new Vector3())
    {
        hero = Instantiate(heroes[i]);
        Debug.Log(position);
        if (position != new Vector3(0,0,0))
            hero.transform.position = position;
        else
            hero.transform.position = spawnBlock.position;
        hero.objectHero = hero.transform.gameObject;
        hero.objectHero.AddComponent<Rigidbody>();
        hero.objectHero.AddComponent<BoxCollider>();
        Created?.Invoke(hero);
    }
    /// <summary>
    /// Метод меняющий героев
    /// Удаляет старого и создает нового
    /// </summary>
    public void ChangeHero()
    {
        var pos = hero.transform.position;
        Destroy(hero.objectHero);
        CreateHero(pos);
    }


    /// <summary>
    /// Метод обработки координат после 
    /// События нажатия на коллайдер пола локации
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
        //Поправить
        //Поварачивает не той стороной
        hero.transform.LookAt(TargetPosition);

        isMoving = true;
    }


    /// <summary>
    /// Метод движения героев
    /// </summary>
    private void Move()
    {
        hero.transform.position = Vector3.MoveTowards
            (hero.transform.position, TargetPosition, speed * Time.deltaTime);
        IsMoving?.Invoke(hero);

        if ((int)(hero.transform.position.x) == (int)(TargetPosition.x) 
            && (int)(hero.transform.position.z) == (int)(TargetPosition.z))
        {
            isMoving = false;
        }

    }
}
