using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Pellet : MonoBehaviour
{
    public Tilemap pellet;
    public static bool poweredUP;

    private void Start()
    {
        poweredUP = false;
        pellet = GetComponent<Tilemap>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            poweredUP = true;
            Vector3 hitPos = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPos.x = hit.point.x - 0.01f * hit.normal.x;
                hitPos.y = hit.point.y - 0.01f * hit.normal.y;
                pellet.SetTile(pellet.WorldToCell(hitPos), null);
            }
            StartCoroutine(powerDown()); 
        }
    }
    IEnumerator powerDown()
    {
        yield return new WaitForSeconds(15);
        poweredUP = false;
    }
}
