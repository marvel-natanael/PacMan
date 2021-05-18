using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public static bool dead;
    public static bool respawn;
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
    public static bool eaten;
    void Start()
    {
        dead = false;
        respawn = false;
        target = FindObjectOfType<PacmanMove>().transform;
        eaten = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!respawn)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            {
                followPlayer();
            }
        }

        if(transform.position == homepos.transform.position)
        {
            StartCoroutine(die());
        }

        if (Pellet.poweredUP)
        {
            spriteRenderer.sprite = newSprite;
            if (eaten)
            {
                spriteRenderer.sprite = runSprite;
            }
            goHome();
        }
        else if(spriteRenderer != runSprite)
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
            if (Pellet.poweredUP)
            {

                PacmanMove.score += 200;
                eaten = true;
                goHome();
            }
            else
            {
                PacmanMove.lives -= 1;
            }

        }
    }
}
