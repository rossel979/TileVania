using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int intplayerLives = 3;
    [SerializeField] int intscore = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livesText.text = intplayerLives.ToString();
        scoreText.text = intscore.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (intplayerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        } 
    }

    public void AddToScore(int pointsToAdd)
    {
        intscore += pointsToAdd;
        scoreText.text = intscore.ToString();
    }

    void TakeLife()
    {
        intplayerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = intplayerLives.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
