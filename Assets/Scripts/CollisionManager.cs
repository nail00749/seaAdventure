using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
   /* public delegate void CollisionDelegate(GameObject gameObject);

    public static event CollisionDelegate CollisionEnter;
    private List<Collider> enemyObjects;

    private void Start()
    {
        enemyObjects = new List<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        var enemyObject = collision.collider;
        if (enemyObject.gameObject.GetComponent<Enemy>())
        {
            if (BarrierCheck(enemyObject.gameObject.GetComponent<Enemy>().passingObject))
            {
                enemyObject.isTrigger = true;
                enemyObjects.Add(enemyObject);
            }
            else
            {
                Debug.Log("Смените персонажа");
                CollisionEnter?.Invoke(enemyObject.gameObject);
            }
        }
        else if (enemyObject.gameObject.GetComponent<Border>())
        {
            //CollisionEnter?.Invoke(enemyObject.gameObject);
        }

    }

    private bool BarrierCheck(List<GameObject> enemy)
    {
        if (name.Contains("(Clone)"))
            name = name.Remove(name.Length - 7);
        for (var i = 0; i < enemy.Count; i++)
        {

            if (enemy[i].name == name)
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        for (var i = 0; i < enemyObjects.Count - 1; i++)
        {
            var enemy = enemyObjects[i];
            if (transform.position.z < enemy.transform.position.z + 20 ||
               transform.position.z > enemy.transform.position.z - 20)
            {
                enemy.isTrigger = false;
            }
        }
    }
    */
}
