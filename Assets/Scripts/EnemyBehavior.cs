using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private bool dead;
    private bool respawn;
    public Transform homepos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    public LayerMask solidLayer;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite runSprite;
    public Sprite curSprite;
    private bool eaten;
    [SerializeField]
    private PacmanMove pm;
    [SerializeField]
    private Pellet pellet;
    void Start()
    {
        dead = false;
        respawn = false;
        target = FindObjectOfType<PacmanMove>().transform;
        eaten = false;
    }

    public bool getDead()
    {
        return dead;
    }
    public bool getRespawn()
    {
        return respawn;
    }
    public bool getEaten()
    {
        return eaten;
    }

    public void setRespawn(bool r)
    {
        respawn = r;
    }
    public void setEaten(bool e)
    {
        eaten = e;
    }
    // Update is called once per frame
    public void enemyMove()
    {
        if (!respawn)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            {
                followPlayer();
            }
        }

        if (transform.position == homepos.transform.position)
        {
            StartCoroutine(die());
        }

        if (pellet.getpUP())
        {
            spriteRenderer.sprite = newSprite;
            if (eaten)
            {
                spriteRenderer.sprite = runSprite;
            }
            goHome();
        }
        else if (spriteRenderer != runSprite)
        {
            spriteRenderer.sprite = curSprite;
        }
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(1);
        dead = true;
        Destroy(gameObject);
    }
    public void followPlayer()
    {
        Debug.Log("a");
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void goHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pellet.getpUP())
            {

                pm.plusScore(200);
                eaten = true;
                goHome();
            }
            else
            {
                pm.hurtPlayer();
            }

        }
    }
}
