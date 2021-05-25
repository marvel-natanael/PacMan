using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.4f;
    private Vector2 dest = Vector2.zero;
    private Vector2 input;
    public LayerMask solidLayer;
    private int lives;
    private int score;
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    private bool valid(Vector3 targetPos) //cek apakah movement valid
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidLayer) != null)
        {
            return false;
        } 
        return true;
    }

    public int getLives()
    {
        return lives;
    }

    public int getScore()
    {
        return score;
    }
    public void plusScore(int s)
    {
        score += s;
    }
    public void plusLives(int l)
    {
        lives += l;
    }
    public void hurtPlayer()
    {
        lives -= 1;
    }
    public void gerak()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        var targetPos = transform.position;
        targetPos.x += input.x;
        targetPos.y += input.y;
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        if (valid(targetPos))
        {
            if (Input.GetKey(KeyCode.UpArrow))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow))
                dest = (Vector2)transform.position - Vector2.right;
        }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
}
