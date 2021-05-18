using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehavior : MonoBehaviour
{
    public int [] value;
    public static int valIndex;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        value = new int[7] {100, 300, 500, 700,1000, 2000, 3000};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PacmanMove.score += value[valIndex];
            if(valIndex<8)
            {
                Destroy(gameObject);
                valIndex++;
            }

        }
    }
}
