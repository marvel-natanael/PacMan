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
    public PacmanMove pm; //ini memanggil class pac man

    private void Start()
    {
        Time.timeScale = 1f;
        restButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        pm.gerak(); // gerak pac man
        textManager();
        dead();
        cekMenang();
    }

    private void cekMenang()
    {
        if (PacDot.count >= 21)
        {
            nextLevel();
        }
    }
    private void textManager()
    {
        levelText.text = "Level\n" + level;
        lives.text = "Lives\n" + PacmanMove.lives;
        score.text = "Score\n" + PacmanMove.score;
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

    private void dead()
    {
        if(PacmanMove.lives == 3)
        {
            Time.timeScale = 0f;
            restButton.gameObject.SetActive(true);
        }
    }
}
