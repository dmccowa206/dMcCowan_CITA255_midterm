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
    public TextMeshProUGUI commentText;
    public static Blaster_script instance;
    public int score;
    public int hp;
    public int highScore;
    readonly List<string> commentList = new();
    int[] commentIntervals;
    private void Awake()//called before Start
    {
        if (instance == null)//Singleton
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
        commentText.text = "";
        commentList.Add("Nice!");
        commentList.Add("Cool!");
        commentList.Add("Awesome!");
        commentList.Add("Radical!");
        commentList.Add("Insane!");
        commentIntervals = new int[commentList.Count];

        for (int i = 0; i < commentList.Count; i++)//set a random interval for every comment
        {
            commentIntervals[i] = UnityEngine.Random.Range((int)10f, (int)50f);
            Debug.Log(i + " location inital interval = " + commentIntervals[i]);
        }
    }
    private void Update()
    {
        if(hp <= 0)//reset if hp = 0
        {
            ResetGame();
        }
    }
    public void UpdateScore()//add 1 to score and update text
    {
        score++;
        scoreText.text = "Score: " + score;
        foreach (string comm in commentList)//check if score matches each comment's interval
        {
            int j = commentList.IndexOf(comm);
            if (score % commentIntervals[j] == 0)
            {
                commentText.text = comm;
                commentIntervals[j] += UnityEngine.Random.Range((int)-9f, (int)9f);//randomly alter the interval
                if (commentIntervals[j] < 5 )//prevent divide by 0
                {
                    commentIntervals[j] = 10;
                }
                Debug.Log(j + " location interval = " + commentIntervals[j]);
            }
        }
    }
    public void UpdateHp()//subtract 1 hp and update text
    {
        hp--;
        healthText.text = "HP: " + hp;
        commentText.text = "Ouch";
    }
    public void ResetGame()
    {
        if(score > highScore)//if score is bigger than high score save it
        {
            highScore = score;
        }
        score = 0;//reset score, hp, and all text
        hp = 3;
        scoreText.text = "Score: " + score;
        healthText.text = "HP: " + hp;
        hiScText.text = "High Score: " + highScore;
        commentText.text = "";
        SceneManager.LoadScene("BlasterMain");//reload scene
    }
}