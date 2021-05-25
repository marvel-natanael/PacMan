using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehavior : MonoBehaviour
{
    public int [] value;
    private int valIndex;
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    private PacmanMove pm;
    // Start is called before the first frame update
    void Start()
    {
        value = new int[7] {100, 300, 500, 700,1000, 2000, 3000};
    }
    public void setValIndex(int v)
    {
        valIndex = v;
    }
    public int getValIndex()
    {
        return valIndex;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pm.plusScore(value[valIndex]);
            if(valIndex<8)
            {
                Destroy(gameObject);
                valIndex++;
            }

        }
    }
}
