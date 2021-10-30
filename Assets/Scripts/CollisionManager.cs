using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public delegate void CollisionDelegate(GameObject gameObject);//+

    public static event CollisionDelegate CollisionEnter;//+

    void OnCollisionEnter(Collision collision)
    {
        var enemyObject = collision.collider;
        if (!enemyObject.gameObject.GetComponent<Enemy>())
            return;
        if (BarrierCheck(enemyObject.gameObject.GetComponent<Enemy>().passingObject))
        {
            enemyObject.isTrigger = true;
        }
        else
        {
            Debug.Log("Смените персонажа");
            CollisionEnter?.Invoke(enemyObject.gameObject);//+
        }
    }

    private bool BarrierCheck(List<GameObject> enemy)
    {
        if(name.Contains("(Clone)"))
            name = name.Remove(name.Length-7);
        for (var i = 0; i < enemy.Count; i++)
        {

            if(enemy[i].name == name)
            {
                return true;
            }
        }
        return false;
    }

}
