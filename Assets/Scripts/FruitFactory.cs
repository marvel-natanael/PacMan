using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitFactory : MonoBehaviour
{
    private bool taken;
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private Fruit[] factory;
    // Start is called before the first frame update
    void Start()
    {
        taken = false;
    }

    public bool getTaken()
    {
        return taken;
    }

    public void spawnFruit(int s)
    {
        if (!taken)
        {
            var inst = factory[s].getNewInstance();
            inst.transform.position = spawnPos.transform.position;
            inst.GetComponent<FruitBehavior>().enabled = true;
            inst.GetComponent<CircleCollider2D>().enabled = true;
            taken = true;
        }
    }

}
