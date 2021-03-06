using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private Transform homePos;
    [SerializeField]
    private Enemy[] factory;
    private int toSpawn;
    string tagName;
    [SerializeField]
    private EnemyBehavior[] enemyBehavior;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        tagName = coll.gameObject.tag;
        Debug.Log(tagName);
        switch (tagName)
        {
            case "pink":
                toSpawn = 0;
                break;
            case "red":
                toSpawn = 1;
                break;
            case "blue":
                toSpawn = 2;
                break;
            case "orange":
                toSpawn = 3;
                break;
        }
        enemyBehavior[toSpawn].setEaten(false);
    }
    public void spawnEnemy()
    {
        if (enemyBehavior[toSpawn].getDead())
        {
            var inst = factory[toSpawn].getNewInstance();
            inst.transform.position = homePos.transform.position;
            inst.GetComponent<EnemyBehavior>().enabled = true;
            inst.GetComponent<CircleCollider2D>().enabled = true;
            enemyBehavior[toSpawn].setRespawn(false);
        }
    }
}
