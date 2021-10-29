using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public delegate void CollisionDelegate(GameObject gameObject);

    public static event CollisionDelegate CollisionEnter;

    void OnCollisionEnter(Collision collision)
    {
        var enemyObject = collision.collider;
        if (!enemyObject.gameObject.GetComponent<Enemy>())
            return;

        

        if (CheckingTheHero(enemyObject.gameObject))
        {
            enemyObject.isTrigger = true;
        }
        else
        {
            Debug.Log("Смените персонажа");
            CollisionEnter?.Invoke(enemyObject.gameObject);
        }
    }

    private bool CheckingTheHero(GameObject enemy)
    {
        switch (enemy.name)
        {
            case "ship_v1":
                if (transform.name == "fish_yozh" || transform.name == "fish_yozh(Clone)")
                    return true;
                break;
            case "ship_v2":
                if (transform.name == "fish_yozh" || transform.name == "fish_yozh(Clone)")
                    return true;
                break;
        }

        return false;
    }

}
