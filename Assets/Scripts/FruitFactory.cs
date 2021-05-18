using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitFactory : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private Fruit[] factory;
    private bool taken;
    // Start is called before the first frame update
    void Start()
    {
        taken = false;
    }

    // Update is called once per frame
    void Update()
    {
        //untuk spawn
        if (!taken)
        {
            var inst = factory[FruitBehavior.valIndex].getNewInstance();
            inst.transform.position = spawnPos.transform.position;
            inst.GetComponent<FruitBehavior>().enabled = true;
            inst.GetComponent<CircleCollider2D>().enabled = true;
            taken = true;
        }
    }
}
