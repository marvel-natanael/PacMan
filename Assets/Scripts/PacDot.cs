using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacDot : MonoBehaviour
{
    public Tilemap dots;
    public int count;
    [SerializeField]
    private PacmanMove pm;

    public int getCount()
    {
        return count;
    }
    private void Start()
    {
        count = 0;
        dots = GetComponent<Tilemap>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //menambah score dan menghilangkan objek setelah diambil
        if(collision.gameObject.CompareTag("Player"))
        {
            pm.plusScore(10);
            count++;
            Vector3 hitPos = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPos.x = hit.point.x - 0.01f*hit.normal.x;
                hitPos.y = hit.point.y - 0.01f * hit.normal.y;
                dots.SetTile(dots.WorldToCell(hitPos), null);
            }
        }
    }
}
