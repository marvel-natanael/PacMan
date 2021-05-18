using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private Transform homePos;
    [SerializeField]
    private Enemy[] factory;
    int toSpawn;
    string tagName;

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
        EnemyBehavior.eaten = false;
    }
    private void Update()
    {
        if (EnemyBehavior.dead)
        {
            var inst = factory[toSpawn].getNewInstance();
            inst.transform.position = homePos.transform.position;
            inst.GetComponent<EnemyBehavior>().enabled = true;
            inst.GetComponent<CircleCollider2D>().enabled = true;
            EnemyBehavior.respawn = false;
        }
    }
}
