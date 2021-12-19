using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject startButton, tapImage, player, endPanel, obstacle, diamondPrefab;

    float lastPosX;

    int diamonds, score, highScore;

    [SerializeField]
    TMP_Text diamondsText, scoreText, highScoreText, highScoreEndText;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        startButton.SetActive(true);
        tapImage.SetActive(true);
        endPanel.SetActive(false);

        lastPosX = 5f;

        score = 0;
        diamonds = PlayerPrefs.HasKey("Diamonds") ? PlayerPrefs.GetInt("Diamonds") : 0;
        highScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        scoreText.text = score.ToString();
        diamondsText.text = diamonds.ToString();
        highScoreText.text = "HighScore : " + highScore.ToString();
    }

    public void GameStart()
    {
        startButton.SetActive(false);
        tapImage.SetActive(false);
        player.GetComponent<Player>().PlayerStart();
        InvokeRepeating("SpawnObstacle", 0f, 1.5f);
    }

    void SpawnObstacle()
    {
        GameObject temp = Instantiate(obstacle);
        temp.transform.position = new Vector3(lastPosX,Random.Range(-2f,2f),obstacle.transform.position.z);
        if(Random.Range(0,2) == 0)
        {
            Instantiate(diamondPrefab, temp.transform.position, Quaternion.identity);
        }
        lastPosX += (4 + Random.Range(0f, 2f));
    }

    public void UpdateDiamonds()
    {
        diamonds++;
        PlayerPrefs.SetInt("Diamonds", diamonds);
        diamondsText.text = diamonds.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameEnd()
    {
        endPanel.SetActive(true);
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        CancelInvoke("SpawnObstacle");
        highScoreEndText.text = "HighScore : "  + highScore.ToString();
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
