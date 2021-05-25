using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    private static int level = 1;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI score;
    public Button restButton;
    public Button startButton;
    private bool start;
    [SerializeField]
    private PacmanMove pacMan;
    [SerializeField]
    private EnemyBehavior[] enemyBehavior;
    [SerializeField]
    private EnemyFactory enemyFactory;
    [SerializeField]
    private FruitFactory fruitFactory;
    [SerializeField]
    private PacDot pacDot;

    private void Start()
    {

        Time.timeScale = 0f;
        startButton.gameObject.SetActive(true);
        restButton.gameObject.SetActive(false);
        start = false;
    }
    // Update is called once per frame
    void Update() //while (playing)
    {
        if(start)
        playGame();
    }

    public void startGame()
    {
        start = true;
    }
    void playGame()
    {
        Time.timeScale = 1f;
        startButton.gameObject.SetActive(false);
        pacMan.gerak(); // gerak pac man

        enemyBehavior[0].enemyMove();
        //enemyBehavior[1].enemyMove();
        //enemyBehavior[2].enemyMove();
        //enemyBehavior[3].enemyMove();

        textManager();
        cekMati();
        cekMenang();
        enemyFactory.spawnEnemy();

        int toSpawn = level - 1;
        if (level > 6)
        {
            toSpawn = 6;
        }
        fruitFactory.spawnFruit(toSpawn);
    }
    private void cekMenang()
    {
        if (pacDot.getCount() >= 21)
        {
            nextLevel();
        }
    }
    private void textManager()
    {
        levelText.text = "Level\n" + level;
        lives.text = "Lives\n" + pacMan.getLives();
        score.text = "Score\n" + pacMan.getScore();
    }
    public void resetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void nextLevel()
    {
        level++;
        SceneManager.LoadScene("SampleScene");
    }

    private void cekMati()
    {
        if(pacMan.getLives() == 3)
        {
            Time.timeScale = 0f;
            restButton.gameObject.SetActive(true);
        }
    }
}
