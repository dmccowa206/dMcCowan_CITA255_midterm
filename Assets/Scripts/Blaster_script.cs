using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blaster_script : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hiScText;
    public static Blaster_script instance;
    public int score;
    public int hp;
    public int highScore;
    public int timeStart;
    private void Awake()//called before Start
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
        hp = 3;
        scoreText.text = "Score: " + score;
        healthText.text = "HP: " + hp;
        hiScText.text = "High Score: " + highScore;
    }
    private void Update()
    {
        if(hp <= 0)
        {
            ResetGame();
        }
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    public void UpdateHp()
    {
        hp--;
        healthText.text = "HP: " + hp;
    }
    public void ResetGame()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        score = 0;
        hp = 3;
        scoreText.text = "Score: " + score;
        healthText.text = "HP: " + hp;
        hiScText.text = "High Score: " + highScore;
        SceneManager.LoadScene("BlasterMain");
    }
}