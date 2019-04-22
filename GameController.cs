using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public new GameObject gameObject;
    public GameObject space;
    public GameObject boundry;
    BGScroller space_script;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public AudioClip victoryMusic;
    public AudioClip deathMusic;
    public AudioSource backgorundMusic;
    public bool alreadyPlayed = false;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text livesText;
    private int score;
    private int lives;

    public bool gameOver;
    private bool restart;
    public bool win;

    void Start()
    {
        gameOver = false;
        restart = false;
        win = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        lives = 3;
        SetAllText();
        boundry.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' to Restart";
                restart = true;
                break;
            }
            else if (win)
            {
                restartText.text = "Press 'Q' to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

   public void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 400)
        {
            
            winText.text = "GAME CREATED BY AUGUSTO LLAMAS";
            win = true;
            backgorundMusic.clip = victoryMusic;
            backgorundMusic.Play();
            Destroy(GameObject.FindWithTag("Enemy"));
            boundry.SetActive(true);
            EndGame();
            
        }
    }
    public void GameOver()
    {
        lives = lives - 1;
        SetAllText();
        if (lives <= 0 && score <= 400)
        {
            Destroy(gameObject);
            gameOverText.text = "GAME OVER";
            gameOver = true;
            backgorundMusic.clip = deathMusic;
            backgorundMusic.Play();
        }
    }
    public void SetAllText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
    void EndGame()
    {
        if (score >= 400)
        {
            ScoreText.text = "Points: 400";
        }
    }

}